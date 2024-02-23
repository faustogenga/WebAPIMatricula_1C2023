using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebAPI.Helpers;
using WebAPI.Services;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
namespace WebAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddHttpContextAccessor();

            services.AddDbContext<DataContext>();
            services.AddCors();
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            // services.AddAutoMapper(typeof(AutoMapperProfile));



            // configure strongly typed settings objects
            var appSettingsSection = _configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                        var userId = int.Parse(context.Principal.Identity.Name);
                        var user = userService.GetById(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    LifetimeValidator = TokenLifetimeValidator.Validate
                };
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext dataContext)
        {

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            string stringConexion = Encriptar(@"Data Source=FAUSTOS-MSI\MSSQLSERVER01;Initial catalog=MATRICULA_1C2023;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");

            //string stringConexion = Encriptar(@"Server=tcp:server.database.windows.net,1433;Database=db;User ID=sa@server;Password=Hola;Trusted_Connection=False;Encrypt=True;");
        }

        public static string Encriptar(string pTexto)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(pTexto);
            result = Convert.ToBase64String(encryted);
            return result;
        }
    }

    public static class TokenLifetimeValidator
    {
        public static bool Validate(
            DateTime? notBefore,
            DateTime? expires,
            SecurityToken tokenToValidate,
            TokenValidationParameters @param
        )
        {
            return (expires != null && expires > DateTime.UtcNow);
        }
    }
}