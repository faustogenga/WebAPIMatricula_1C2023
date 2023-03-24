using Api.Bll.Curso;
using Api.Bll.Curso.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIMatricula_1C2023.Controllers
{
    [Route("Api/v1" + "/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class CursoController : Controller
    {

        public LnCurso oLnCurso;

        public CursoController(IAdCurso accesoAdCurso)
        {
            oLnCurso = new LnCurso(accesoAdCurso);
        }

        [HttpPost]
        [Route("AgregarCurso")]
        public IActionResult AgregarCurso([FromBody] Api.Dto.Curso.Entrada.AgregarCurso pDatos)
        {
            Api.Dto.Curso.Salida.AgregarCurso respuesta = new Api.Dto.Curso.Salida.AgregarCurso();
            try
            {
                respuesta = oLnCurso.AgregarCurso(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                //return StatusCode(StatusCodes.Status500InternalServerError, ex);
                return Ok(ex.Message);
            }
        }

        [HttpPost]
        [Route("VerTodosCursos")]
        public IActionResult VerTodosCursos(Api.Dto.Curso.Entrada.VerTodosCursos pDatos)
        {
            Api.Dto.Curso.Salida.VerTodosCursos respuesta = new Api.Dto.Curso.Salida.VerTodosCursos();

            try
            {
                respuesta = oLnCurso.VerTodosCursos(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                //return StatusCode(StatusCodes.Status500InternalServerError, ex);
                return Ok(respuesta);
            }
        }


        [HttpPost]
        [Route("EliminarCurso")]
        public IActionResult EliminarCurso([FromBody] Api.Dto.Curso.Entrada.EliminarCurso pDatos)
        {
            Api.Dto.Curso.Salida.EliminarCurso respuesta = new Api.Dto.Curso.Salida.EliminarCurso();

            try
            {
                respuesta = oLnCurso.EliminarCurso(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }


        [HttpPost]
        [Route("VerDetalleCurso")]
        public IActionResult VerDetalleCurso([FromBody] Api.Dto.Curso.Entrada.VerDetalleCurso pDatos)
        {
            Api.Dto.Curso.Salida.VerDetalleCurso respuesta = new Api.Dto.Curso.Salida.VerDetalleCurso();

            try
            {
                respuesta = oLnCurso.VerDetalleCurso(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }

        [HttpPost]
        [Route("EditarCurso")]
        public IActionResult EditarCurso([FromBody] Api.Dto.Curso.Entrada.EditarCurso pDatos)
        {
            Api.Dto.Curso.Salida.EditarCurso respuesta = new Api.Dto.Curso.Salida.EditarCurso();

            try
            {
                respuesta = oLnCurso.EditarCurso(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }
    }
}
