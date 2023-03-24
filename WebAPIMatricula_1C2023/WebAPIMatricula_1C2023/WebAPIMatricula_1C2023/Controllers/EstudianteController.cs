using Api.Bll.Estudiante;
using Api.Bll.Estudiante.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiMatricula_1C2023.Controllers
{
    [Route("Api/v1" + "/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class EstudianteController : Controller
    {
        private LnEstudiante oLnEstudiante;

        public EstudianteController(IAdEstudiante accesoAdEstudiante)
        {
            oLnEstudiante = new LnEstudiante(accesoAdEstudiante);
        }

        [HttpPost]
        [Route("AgregarEstudiante")]
        public IActionResult AgregarEstudiante([FromBody] Api.Dto.Estudiante.Entrada.AgregarEstudiante pDatos)
        {
            Api.Dto.Estudiante.Salida.AgregarEstudiante respuesta = new Api.Dto.Estudiante.Salida.AgregarEstudiante();
            try
            {
                respuesta = oLnEstudiante.AgregarEstudiante(pDatos);
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
        [Route("VerTodosEstudiantes")]
        public IActionResult VerTodosEstudiantes(Api.Dto.Estudiante.Entrada.VerTodosEstudiantes pDatos)
        {
            Api.Dto.Estudiante.Salida.VerTodosEstudiantes respuesta = new Api.Dto.Estudiante.Salida.VerTodosEstudiantes();

            try
            {
                respuesta = oLnEstudiante.VerTodosEstudiantes(pDatos);
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
        [Route("EliminarEstudiante")]
        public IActionResult EliminarEstudiante([FromBody] Api.Dto.Estudiante.Entrada.EliminarEstudiante pDatos)
        {
            Api.Dto.Estudiante.Salida.EliminarEstudiante respuesta = new Api.Dto.Estudiante.Salida.EliminarEstudiante();

            try
            {
                respuesta = oLnEstudiante.EliminarEstudiante(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }


        [HttpPost]
        [Route("VerDetalleEstudiante")]
        public IActionResult VerDetalleEstudiante([FromBody] Api.Dto.Estudiante.Entrada.VerDetalleEstudiante pDatos)
        {
            Api.Dto.Estudiante.Salida.VerDetalleEstudiante respuesta = new Api.Dto.Estudiante.Salida.VerDetalleEstudiante();

            try
            {
                respuesta = oLnEstudiante.VerDetalleEstudiante(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }

        [HttpPost]
        [Route("EditarEstudiante")]
        public IActionResult EditarEstudiante([FromBody] Api.Dto.Estudiante.Entrada.EditarEstudiante pDatos)
        {
            Api.Dto.Estudiante.Salida.EditarEstudiante respuesta = new Api.Dto.Estudiante.Salida.EditarEstudiante();

            try
            {
                respuesta = oLnEstudiante.EditarEstudiante(pDatos);
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
