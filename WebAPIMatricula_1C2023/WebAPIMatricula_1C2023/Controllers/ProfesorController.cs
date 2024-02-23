using Api.Bll.Profesor.Interfaces;
using Api.Bll.Profesor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebMatricula1C2023.Controllers
{
    [Route("Api/v1" + "/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class ProfesorController : Controller
    {
        private LnProfesor oLnProfesor;

        public ProfesorController(IAdProfesor accesoAdVehiculoMarchamo)
        {
            oLnProfesor = new LnProfesor(accesoAdVehiculoMarchamo);
        }

        [HttpPost]
        [Route("AgregarProfesor")]
        public IActionResult AgregarProfesor([FromBody] Api.Dto.Profesor.Entrada.AgregarProfesor pDatos)
        {
            Api.Dto.Profesor.Salida.AgregarProfesor respuesta = new Api.Dto.Profesor.Salida.AgregarProfesor();
            try
            {
                respuesta = oLnProfesor.AgregarProfesor(pDatos);
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
        [Route("VerTodosProfesores")]
        public IActionResult VerTodosProfesores(Api.Dto.Profesor.Entrada.VerTodosProfesores pDatos)
        {
            Api.Dto.Profesor.Salida.VerTodosProfesores respuesta = new Api.Dto.Profesor.Salida.VerTodosProfesores();

            try
            {
                respuesta = oLnProfesor.VerTodosProfesores(pDatos);
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
        [Route("EliminarProfesor")]
        public IActionResult EliminarProfesor([FromBody] Api.Dto.Profesor.Entrada.EliminarProfesor pDatos)
        {
            Api.Dto.Profesor.Salida.EliminarProfesor respuesta = new Api.Dto.Profesor.Salida.EliminarProfesor();

            try
            {
                respuesta = oLnProfesor.EliminarProfesor(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }


        [HttpPost]
        [Route("VerDetalleProfesor")]
        public IActionResult VerDetalleProfesor([FromBody] Api.Dto.Profesor.Entrada.VerDetalleProfesor pDatos)
        {
            Api.Dto.Profesor.Salida.VerDetalleProfesor respuesta = new Api.Dto.Profesor.Salida.VerDetalleProfesor();

            try
            {
                respuesta = oLnProfesor.VerDetalleProfesor(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }

        [HttpPost]
        [Route("EditarProfesor")]
        public IActionResult EditarProfesor([FromBody] Api.Dto.Profesor.Entrada.EditarProfesor pDatos)
        {
            Api.Dto.Profesor.Salida.EditarProfesor respuesta = new Api.Dto.Profesor.Salida.EditarProfesor();

            try
            {
                respuesta = oLnProfesor.EditarProfesor(pDatos);
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
