using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.WebMatricula1C2023.Logica;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace UI.WebMatricula1C2023.Controllers
{
    public class CarreraController : Controller
    {
        LnCarrera lnCarrera = new LnCarrera();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            Models.Carrera.Entrada.VerTodasCarreras parametros =
                new Models.Carrera.Entrada.VerTodasCarreras();

            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");

            var listaCarreras = await lnCarrera.VerTodasCarreras(parametros, usuarioActual.Token);

            ////////////////***********GRAFICOS CHART JS//////////////////////*********/
            var random = new Random();

            var etiquetas = new List<string>();
            var colores = new List<string>();
            var valores = new List<string>();

            foreach (var estado in listaCarreras.ListaCarreras.GroupBy(e => e.Idioma)
                .Select(group => new {
                    Idioma = group.Key,
                    Cantidad = group.Count()
                }).OrderBy(x => x.Idioma))
            {
                string color = String.Format("#{0:X6}", random.Next(0x1000000));

                etiquetas.Add(estado.Idioma);
                valores.Add(estado.Cantidad.ToString());
                colores.Add(color);
            }

            ViewBag.Etiquetas = JsonConvert.SerializeObject(etiquetas);
            ViewBag.Valores = JsonConvert.SerializeObject(valores);
            ViewBag.Colores = JsonConvert.SerializeObject(colores);
            ////////////////***********GRAFICOS CHART JS//////////////////////*********/

            return View(listaCarreras.ListaCarreras);
        }

        [HttpPost]
        public async Task<JsonResult> AgregarCarrera(Models.Carrera.Entrada.AgregarCarrera agregarCarrera)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnCarrera.AgregarCarrera(agregarCarrera, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("La Carrera: {0} ha sido ingresada con éxito.", agregarCarrera.Carrera));
            else
                return Json(String.Format("La Carrera: {0} no fue ingresada.", agregarCarrera.Carrera));
        }

        [HttpPost]
        public async Task<JsonResult> EditarCarrera(Models.Carrera.Entrada.EditarCarrera editarCarrera)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnCarrera.EditarCarrera(editarCarrera, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("La Carrera: {0} ha sido modificada con éxito.", editarCarrera.Carrera));
            else
                return Json(String.Format("La Carrera: {0} no fue modificada.", editarCarrera.Carrera));
        }

        [HttpPost]
        public async Task<JsonResult> EliminarCarrera(Models.Carrera.Entrada.EliminarCarrera eliminarCarrera)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnCarrera.EliminarCarrera(eliminarCarrera, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("La Carrera: {0} ha sido eliminada con éxito.", eliminarCarrera.Codigo));
            else
                return Json(String.Format("La Carrera: {0} no fue eliminada.", eliminarCarrera.Codigo));
        }

        [HttpPost]
        public async Task<JsonResult> VerDetalleCarrera(Models.Carrera.Entrada.VerDetalleCarrera verDetalleCarrera)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var respuesta = await lnCarrera.VerDetalleCarrera(verDetalleCarrera, usuarioActual.Token);

            return Json(respuesta);
        }


    }
}
