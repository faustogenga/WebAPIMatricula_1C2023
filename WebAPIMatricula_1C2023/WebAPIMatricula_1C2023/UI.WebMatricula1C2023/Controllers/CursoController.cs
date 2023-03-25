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
            Models.Curso.Entrada.VerTodosCursos parametros = 
                new Models.Curso.Entrada.VerTodosCursos();

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

        // GET: CursoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CursoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CursoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CursoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CursoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CursoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CursoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
