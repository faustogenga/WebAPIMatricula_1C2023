using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.WebMatricula1C2023.Logica;

namespace UI.WebMatricula1C2023.Controllers
{
    public class EstudianteController : Controller
    {
        LnEstudiante lnEstudiante = new LnEstudiante();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            Models.Estudiante.Entrada.VerTodosEstudiantes parametros = 
                new Models.Estudiante.Entrada.VerTodosEstudiantes();

            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");

            var listaEstudiantes = await lnEstudiante.VerTodosEstudiantes(parametros, usuarioActual.Token);

            ////////////////***********GRAFICOS CHART JS//////////////////////*********/
            var random = new Random();

            var etiquetas = new List<string>();
            var colores = new List<string>();
            var valores = new List<string>();

            foreach(var estado in listaEstudiantes.ListaEstudiantes.GroupBy(e => e.Estado)
                .Select(group => new { 
                    Estado = group.Key,
                    Cantidad = group.Count()
                }).OrderBy(x => x.Estado))
            {
                string color = String.Format("#{0:X6}", random.Next(0x1000000));

                etiquetas.Add(estado.Estado);
                valores.Add(estado.Cantidad.ToString());
                colores.Add(color);
            }

            ViewBag.Etiquetas = JsonConvert.SerializeObject(etiquetas);
            ViewBag.Valores = JsonConvert.SerializeObject(valores);
            ViewBag.Colores = JsonConvert.SerializeObject(colores);
            ////////////////***********GRAFICOS CHART JS//////////////////////*********/

            return View(listaEstudiantes.ListaEstudiantes);
        }

        [HttpPost]
        public async Task<JsonResult> AgregarEstudiante(Models.Estudiante.Entrada.AgregarEstudiante agregarEstudiante)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnEstudiante.AgregarEstudiante(agregarEstudiante, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El estudiante: {0} ha sido ingresado con éxito.",agregarEstudiante.NombreCompleto));
            else
                return Json(String.Format("El estudiante: {0} no fue ingresado.", agregarEstudiante.NombreCompleto));
        }

        [HttpPost]
        public async Task<JsonResult> EditarEstudiante(Models.Estudiante.Entrada.EditarEstudiante editarEstudiante)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnEstudiante.EditarEstudiante(editarEstudiante, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El estudiante: {0} ha sido modificado con éxito.", editarEstudiante.NombreCompleto));
            else
                return Json(String.Format("El estudiante: {0} no fue modificado.", editarEstudiante.NombreCompleto));
        }

        [HttpPost]
        public async Task<JsonResult> EliminarEstudiante(Models.Estudiante.Entrada.EliminarEstudiante eliminarEstudiante)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnEstudiante.EliminarEstudiante(eliminarEstudiante, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El estudiante: {0} ha sido eliminado con éxito.", eliminarEstudiante.Codigo));
            else
                return Json(String.Format("El estudiante: {0} no fue eliminado.", eliminarEstudiante.Codigo));
        }

        [HttpPost]
        public async Task<JsonResult> VerDetalleEstudiante(Models.Estudiante.Entrada.VerDetalleEstudiante verDetalleEstudiante)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var respuesta = await lnEstudiante.VerDetalleEstudiante(verDetalleEstudiante, usuarioActual.Token);
            
            return Json(respuesta);
        }


    }
}
