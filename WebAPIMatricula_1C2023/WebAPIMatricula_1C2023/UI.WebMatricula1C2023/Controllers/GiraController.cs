using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.WebMatricula1C2023.Logica;

namespace UI.WebMatricula1C2023.Controllers
{
    public class GiraController : Controller
    {
        LnGira lnGira = new LnGira();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            Models.Gira.Entrada.VerTodasGiras parametros = 
                new Models.Gira.Entrada.VerTodasGiras();

            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");

            var listaGiras = await lnGira.VerTodosGiras(parametros, usuarioActual.Token);

            ////////////////***********GRAFICOS CHART JS//////////////////////*********/
            var random = new Random();

            var etiquetas = new List<string>();
            var colores = new List<string>();
            var valores = new List<string>();

            foreach(var estado in listaGiras.ListaGiras.GroupBy(e => e.Tipo).Select(group => new { 
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

            return View(listaGiras.ListaGiras);
        }

        [HttpPost]
        public async Task<JsonResult> AgregarGira(Models.Gira.Entrada.AgregarGira agregarGira)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnGira.AgregarGira(agregarGira, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El Gira: {0} ha sido ingresado con éxito.",agregarGira.Organizacion));
            else
                return Json(String.Format("El Gira: {0} no fue ingresado.", agregarGira.Organizacion));
        }

        [HttpPost]
        public async Task<JsonResult> EditarGira(Models.Gira.Entrada.EditarGira editarGira)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnGira.EditarGira(editarGira, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El Gira: {0} ha sido modificado con éxito.", editarGira.Organizacion));
            else
                return Json(String.Format("El Gira: {0} no fue modificado.", editarGira.Organizacion));
        }

        [HttpPost]
        public async Task<JsonResult> EliminarGira(Models.Gira.Entrada.EliminarGira eliminarGira)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnGira.EliminarGira(eliminarGira, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El Gira: {0} ha sido eliminado con éxito.", eliminarGira.Codigo));
            else
                return Json(String.Format("El Gira: {0} no fue eliminado.", eliminarGira.Codigo));
        }

        [HttpPost]
        public async Task<JsonResult> VerDetalleGira(Models.Gira.Entrada.VerDetalleGira verDetalleGira)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var respuesta = await lnGira.VerDetalleGira(verDetalleGira, usuarioActual.Token);
            
            return Json(respuesta);
        }


    }
}
