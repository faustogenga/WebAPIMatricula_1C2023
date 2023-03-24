using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using UI.WebMatricula1C2023.Logica;
using UI.WebMatricula1C2023.Models;

namespace UI.WebMatricula1C2023.Controllers
{
    public class AccesoController : Controller
    {
        public async Task<ActionResult> Index(Models.Users.AuthenticateModel pDatos)
        {
            if (!string.IsNullOrEmpty(pDatos.Username) && !string.IsNullOrEmpty(pDatos.Password))
            {
                UsersController usersController = new UsersController();
                var usuario = usersController.Authenticate(pDatos.Username, pDatos.Password);

                if (!string.IsNullOrEmpty(usuario.Result.Token))
                {

                    var claims = new List<Claim>
                    {
                        new Claim("Codigo", usuario.Result.Codigo.ToString()),
                        new Claim("Identificacion", usuario.Result.Identificacion),
                        new Claim("NombreCompleto", usuario.Result.NombreCompleto),
                        new Claim("CorreoElectronico", usuario.Result.CorreoElectronico),
                        new Claim("Username", usuario.Result.Username),
                        new Claim("Estado", usuario.Result.Estado),
                        new Claim("Token", usuario.Result.Token)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    HttpContext.Session.SetObjectAsJson("UsuarioActual", usuario.Result);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LogOnError", "Credenciales incorrectas.");
                    return View("Index");
                }
            }
            else
                return View("Index");
        }

        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Acceso");
        }

        public IActionResult Registro()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
