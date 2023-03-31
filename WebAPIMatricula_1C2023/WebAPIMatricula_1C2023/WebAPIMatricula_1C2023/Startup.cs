using Api.Bll.Carrera.Interfaces;
using Api.Bll.Club.Interfaces;
using Api.Bll.Curso.Interfaces;
using Api.Bll.Error.Interfaces;
using Api.Bll.Estudiante.Interfaces;
using Api.Bll.Gira.Interfaces;
using Api.Bll.Profesor.Interfaces;
using Api.Bll.Residencia.Interfaces;
using Api.Bll.VehiculoMarchamo.Interfaces;
using Api.Dal.Carrera;
using Api.Dal.Club;
using Api.Dal.Curso;
using Api.Dal.Error;
using Api.Dal.Estudiante;
using Api.Dal.Gira;
using Api.Dal.Profesor;
using Api.Dal.Residencia;
using Api.Dal.VehiculoMarchamo;
using Api.Dto.General;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebAPI;
using WebAPI.Services;

namespace WebMatricula1C2023
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>
                (Configuration.GetSection("AppSettings").GetSection("ConnectionStrings"));

            var appSettingsSection = Configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            services.AddDbContext<WebAPI.Helpers.DataContext>();
            services.Configure<AppSettings>(appSettingsSection);

            #region JWT
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).
            AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<WebAPI.Services.IUserService>();
                        var userId = int.Parse(context.Principal.Identity.Name);
                        var user = userService.GetById(userId);

                        if (user == null)
                        {
                            context.Fail("Unauthorized");
                        }

                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
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
            #endregion

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAdEstudiante, AdEstudiante>();
            services.AddScoped<IAdError, AdError>();
            services.AddScoped<IAdCurso, AdCurso>();
            services.AddScoped<IAdClub, AdClub>();
            services.AddScoped<IAdGira, AdGira>();
            services.AddScoped<IAdCarrera, AdCarrera>();
            services.AddScoped<IAdProfesor, AdProfesor>();
            services.AddScoped<IAdResidencia, AdResidencia>();
            services.AddScoped<IAdVehiculoMarchamo, AdVehiculoMarchamo>();




            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiMatricula", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiMatricula v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            //USO DE WEB Api CON JWT
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
