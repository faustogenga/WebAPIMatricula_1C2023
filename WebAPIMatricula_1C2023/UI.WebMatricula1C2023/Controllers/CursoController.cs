using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.WebMatricula1C2023.Logica;

namespace UI.WebMatricula1C2023.Controllers
{
    public class CursoController : Controller
    {
        LnCurso lnCurso = new LnCurso();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        // GET: CursoController
        public async Task<IActionResult> Index()
        {
            Models.Curso.Entrada.VerTodosCursos parametros = new Models.Curso.Entrada.VerTodosCursos();

            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");

            var listaCursos = await lnCurso.VerTodosCursos(parametros, usuarioActual.Token);

            var random = new Random();

            var etiquetas = new List<string>();
            var colores = new List<string>();
            var valores = new List<string>();

            foreach (var estado in listaCursos.ListaCursos.GroupBy(e => e.Estado).Select(group => new {
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

            return View(listaCursos.ListaCursos);
        }

        [HttpPost]
        public async Task<JsonResult> AgregarCurso(Models.Curso.Entrada.AgregarCurso agregarCurso)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnCurso.AgregarCurso(agregarCurso, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El curso: {0} ha sido ingresado con éxito.", agregarCurso.Nombre));
            else
                return Json(String.Format("El curso: {0} no fue ingresado.", agregarCurso));
        }

        [HttpPost]
        public async Task<JsonResult> EditarCurso(Models.Curso.Entrada.EditarCurso editarCurso)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnCurso.EditarCurso(editarCurso, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El Curso: {0} ha sido modificado con éxito.", editarCurso.Nombre));
            else
                return Json(String.Format("El Curso: {0} no fue modificado.", editarCurso.Nombre));
        }

        [HttpPost]
        public async Task<JsonResult> EliminarCurso(Models.Curso.Entrada.EliminarCurso eliminarCurso)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnCurso.EliminarCurso(eliminarCurso, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El Curso: {0} ha sido eliminado con éxito.", eliminarCurso.Codigo));
            else
                return Json(String.Format("El Curso: {0} no fue eliminado.", eliminarCurso.Codigo));
        }

        [HttpPost]
        public async Task<JsonResult> VerDetalleCurso(Models.Curso.Entrada.VerDetalleCurso verDetalleCurso)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var respuesta = await lnCurso.VerDetalleCurso(verDetalleCurso, usuarioActual.Token);

            return Json(respuesta);
        }
    }
}
