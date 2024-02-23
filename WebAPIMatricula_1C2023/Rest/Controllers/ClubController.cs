using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.WebMatricula1C2023.Logica;

namespace UI.WebMatricula1C2023.Controllers
{
    public class ClubController : Controller
    {
        LnClub lnClub = new LnClub();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            Models.Club.Entrada.VerTodosClubes parametros = 
                new Models.Club.Entrada.VerTodosClubes();

            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");

            var listaClubes = await lnClub.VerTodosClubes(parametros, usuarioActual.Token);

            ////////////////***********GRAFICOS CHART JS//////////////////////*********/
            var random = new Random();

            var etiquetas = new List<string>();
            var colores = new List<string>();
            var valores = new List<string>();

            foreach(var estado in listaClubes.ListaClubes.GroupBy(e => e.Tipo).Select(group => new { 
                    Tipo = group.Key,
                    Cantidad = group.Count()
                }).OrderBy(x => x.Tipo))
            {
                string color = String.Format("#{0:X6}", random.Next(0x1000000));

                etiquetas.Add(estado.Tipo);
                valores.Add(estado.Cantidad.ToString());
                colores.Add(color);
            }

            ViewBag.Etiquetas = JsonConvert.SerializeObject(etiquetas);
            ViewBag.Valores = JsonConvert.SerializeObject(valores);
            ViewBag.Colores = JsonConvert.SerializeObject(colores);
            ////////////////***********GRAFICOS CHART JS//////////////////////*********/

            return View(listaClubes.ListaClubes);
        }

        [HttpPost]
        public async Task<JsonResult> AgregarClub(Models.Club.Entrada.AgregarClub agregarClub)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnClub.AgregarClub(agregarClub, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El Club: {0} ha sido ingresado con éxito.",agregarClub.Nombre));
            else
                return Json(String.Format("El Club: {0} no fue ingresado.", agregarClub.Nombre));
        }

        [HttpPost]
        public async Task<JsonResult> EditarClub(Models.Club.Entrada.EditarClub editarClub)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnClub.EditarClub(editarClub, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El Club: {0} ha sido modificado con éxito.", editarClub.Nombre));
            else
                return Json(String.Format("El Club: {0} no fue modificado.", editarClub.Nombre));
        }

        [HttpPost]
        public async Task<JsonResult> EliminarClub(Models.Club.Entrada.EliminarClub eliminarClub)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnClub.EliminarClub(eliminarClub, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El Club: {0} ha sido eliminado con éxito.", eliminarClub.Codigo));
            else
                return Json(String.Format("El Club: {0} no fue eliminado.", eliminarClub.Codigo));
        }

        [HttpPost]
        public async Task<JsonResult> VerDetalleClub(Models.Club.Entrada.VerDetalleClub verDetalleClub)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var respuesta = await lnClub.VerDetalleClub(verDetalleClub, usuarioActual.Token);
            
            return Json(respuesta);
        }


    }
}
