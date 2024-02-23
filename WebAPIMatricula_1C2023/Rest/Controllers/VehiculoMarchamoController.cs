using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.WebMatricula1C2023.Logica;

namespace UI.WebMatricula1C2023.Controllers
{
    public class VehiculoMarchamoController : Controller
    {
        LnVehiculoMarchamo lnVehiculoMarchamo = new LnVehiculoMarchamo();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            Models.VehiculoMarchamo.Entrada.VerTodosVehiculoMarchamos parametros =
                new Models.VehiculoMarchamo.Entrada.VerTodosVehiculoMarchamos();

            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");

            var listaVehiculoMarchamos = await lnVehiculoMarchamo.VerTodosVehiculoMarchamos(parametros, usuarioActual.Token);

            ////////////////***********GRAFICOS CHART JS//////////////////////*********/
            var random = new Random();

            var etiquetas = new List<string>();
            var colores = new List<string>();
            var valores = new List<string>();

            foreach (var codigo in listaVehiculoMarchamos.ListaVehiculoMarchamos.GroupBy(e => e.ColorVehiculo)
                .Select(group => new {
                    ColorVehiculo = group.Key,
                    Cantidad = group.Count()
                }).OrderBy(x => x.ColorVehiculo))
            {
                string color = String.Format("#{0:X6}", random.Next(0x1000000));

                etiquetas.Add(codigo.ColorVehiculo.ToString());
                valores.Add(codigo.Cantidad.ToString());
                colores.Add(color);
            }

            ViewBag.Etiquetas = JsonConvert.SerializeObject(etiquetas);
            ViewBag.Valores = JsonConvert.SerializeObject(valores);
            ViewBag.Colores = JsonConvert.SerializeObject(colores);
            ////////////////***********GRAFICOS CHART JS//////////////////////*********/

            return View(listaVehiculoMarchamos.ListaVehiculoMarchamos);
        }

        [HttpPost]
        public async Task<JsonResult> AgregarVehiculoMarchamo(Models.VehiculoMarchamo.Entrada.AgregarVehiculoMarchamo agregarVehiculoMarchamo)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnVehiculoMarchamo.AgregarVehiculoMarchamo(agregarVehiculoMarchamo, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El VehiculoMarchamo: {0} ha sido ingresado con éxito.", agregarVehiculoMarchamo.NombreCompleto));
            else
                return Json(String.Format("El VehiculoMarchamo: {0} no fue ingresado.", agregarVehiculoMarchamo.NombreCompleto));
        }

        [HttpPost]
        public async Task<JsonResult> EditarVehiculoMarchamo(Models.VehiculoMarchamo.Entrada.EditarVehiculoMarchamo editarVehiculoMarchamo)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnVehiculoMarchamo.EditarVehiculoMarchamo(editarVehiculoMarchamo, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El VehiculoMarchamo: {0} ha sido modificado con éxito.", editarVehiculoMarchamo.NombreCompleto));
            else
                return Json(String.Format("El VehiculoMarchamo: {0} no fue modificado.", editarVehiculoMarchamo.NombreCompleto));
        }

        [HttpPost]
        public async Task<JsonResult> EliminarVehiculoMarchamo(Models.VehiculoMarchamo.Entrada.EliminarVehiculoMarchamo eliminarVehiculoMarchamo)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnVehiculoMarchamo.EliminarVehiculoMarchamo(eliminarVehiculoMarchamo, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El VehiculoMarchamo: {0} ha sido eliminado con éxito.", eliminarVehiculoMarchamo.Codigo));
            else
                return Json(String.Format("El VehiculoMarchamo: {0} no fue eliminado.", eliminarVehiculoMarchamo.Codigo));
        }

        [HttpPost]
        public async Task<JsonResult> VerDetalleVehiculoMarchamo(Models.VehiculoMarchamo.Entrada.VerDetalleVehiculoMarchamo verDetalleVehiculoMarchamo)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var respuesta = await lnVehiculoMarchamo.VerDetalleVehiculoMarchamo(verDetalleVehiculoMarchamo, usuarioActual.Token);

            return Json(respuesta);
        }


    }
}
