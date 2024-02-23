using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.WebMatricula1C2023.Logica;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace UI.WebMatricula1C2023.Controllers
{
    public class ResidenciaController : Controller
    {
        LnResidencia lnResidencia = new LnResidencia();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            Models.Residencia.Entrada.VerTodasResidencias parametros =
                new Models.Residencia.Entrada.VerTodasResidencias();

            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");

            var listaResidencias = await lnResidencia.VerTodasResidencias(parametros, usuarioActual.Token);

            ////////////////***********GRAFICOS CHART JS//////////////////////*********/
            var random = new Random();

            var etiquetas = new List<string>();
            var colores = new List<string>();
            var valores = new List<string>();

            foreach (var estado in listaResidencias.ListaResidencias.GroupBy(e => e.Provincia)
                .Select(group => new {
                    Provincia = group.Key,
                    Cantidad = group.Count()
                }).OrderBy(x => x.Provincia))
            {
                string color = String.Format("#{0:X6}", random.Next(0x1000000));

                etiquetas.Add(estado.Provincia); 
                valores.Add(estado.Cantidad.ToString());
                colores.Add(color);
            }

            ViewBag.Etiquetas = JsonConvert.SerializeObject(etiquetas);
            ViewBag.Valores = JsonConvert.SerializeObject(valores);
            ViewBag.Colores = JsonConvert.SerializeObject(colores);
            ////////////////***********GRAFICOS CHART JS//////////////////////*********/

            return View(listaResidencias.ListaResidencias);
        }

        [HttpPost]
        public async Task<JsonResult> AgregarResidencia(Models.Residencia.Entrada.AgregarResidencia agregarResidencia)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnResidencia.AgregarResidencia(agregarResidencia, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("La residencia: {0} ha sido ingresada con éxito.", agregarResidencia.Pais));
            else
                return Json(String.Format("La residencia: {0} no fue ingresada.", agregarResidencia.Pais));
        }

        [HttpPost]
        public async Task<JsonResult> EditarResidencia(Models.Residencia.Entrada.EditarResidencia editarResidencia)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnResidencia.EditarResidencia(editarResidencia, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("La residencia: {0} ha sido modificada con éxito.", editarResidencia.Pais));
            else
                return Json(String.Format("La residencia: {0} no fue modificada.", editarResidencia.Pais));
        }

        [HttpPost]
        public async Task<JsonResult> EliminarResidencia(Models.Residencia.Entrada.EliminarResidencia eliminarResidencia)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnResidencia.EliminarResidencia(eliminarResidencia, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("La residencia: {0} ha sido eliminada con éxito.", eliminarResidencia.Codigo));
            else
                return Json(String.Format("La residencia: {0} no fue eliminada.", eliminarResidencia.Codigo));
        }

        [HttpPost]
        public async Task<JsonResult> VerDetalleResidencia(Models.Residencia.Entrada.VerDetalleResidencia verDetalleResidencia)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var respuesta = await lnResidencia.VerDetalleResidencia(verDetalleResidencia, usuarioActual.Token);

            return Json(respuesta);
        }


    }
}
