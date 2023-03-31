using Api.Bll.VehiculoMarchamo.Interfaces;
using Api.Bll.VehiculoMarchamo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Bll.VehiculoMarchamo;

namespace WebMatricula1C2023.Controllers
{

    [Route("Api/v1" + "/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class VehiculoMarchamoController : Controller
    {
        private LnVehiculoMarchamo oLnVehiculoMarchamo;

        public VehiculoMarchamoController(IAdVehiculoMarchamo accesoAdVehiculoMarchamo)
        {
            oLnVehiculoMarchamo = new LnVehiculoMarchamo(accesoAdVehiculoMarchamo);
        }

        [HttpPost]
        [Route("AgregarVehiculoMarchamo")]
        public IActionResult AgregarVehiculoMarchamo([FromBody] Api.Dto.VehiculoMarchamo.Entrada.AgregarVehiculoMarchamo pDatos)
        {
            Api.Dto.VehiculoMarchamo.Salida.AgregarVehiculoMarchamo respuesta = new Api.Dto.VehiculoMarchamo.Salida.AgregarVehiculoMarchamo();
            try
            {
                respuesta = oLnVehiculoMarchamo.AgregarVehiculoMarchamo(pDatos);
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
        [Route("VerTodosVehiculoMarchamos")]
        public IActionResult VerTodosVehiculoMarchamos(Api.Dto.VehiculoMarchamo.Entrada.VerTodosVehiculoMarchamos pDatos)
        {
            Api.Dto.VehiculoMarchamo.Salida.VerTodosVehiculoMarchamos respuesta = new Api.Dto.VehiculoMarchamo.Salida.VerTodosVehiculoMarchamos();

            try
            {
                respuesta = oLnVehiculoMarchamo.VerTodosVehiculoMarchamos(pDatos);
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
        [Route("EliminarVehiculoMarchamo")]
        public IActionResult EliminarVehiculoMarchamo([FromBody] Api.Dto.VehiculoMarchamo.Entrada.EliminarVehiculoMarchamo pDatos)
        {
            Api.Dto.VehiculoMarchamo.Salida.EliminarVehiculoMarchamo respuesta = new Api.Dto.VehiculoMarchamo.Salida.EliminarVehiculoMarchamo();

            try
            {
                respuesta = oLnVehiculoMarchamo.EliminarVehiculoMarchamo(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }


        [HttpPost]
        [Route("VerDetalleVehiculoMarchamo")]
        public IActionResult VerDetalleVehiculoMarchamo([FromBody] Api.Dto.VehiculoMarchamo.Entrada.VerDetalleVehiculoMarchamo pDatos)
        {
            Api.Dto.VehiculoMarchamo.Salida.VerDetalleVehiculoMarchamo respuesta = new Api.Dto.VehiculoMarchamo.Salida.VerDetalleVehiculoMarchamo();

            try
            {
                respuesta = oLnVehiculoMarchamo.VerDetalleVehiculoMarchamo(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }

        [HttpPost]
        [Route("EditarVehiculoMarchamo")]
        public IActionResult EditarVehiculoMarchamo([FromBody] Api.Dto.VehiculoMarchamo.Entrada.EditarVehiculoMarchamo pDatos)
        {
            Api.Dto.VehiculoMarchamo.Salida.EditarVehiculoMarchamo respuesta = new Api.Dto.VehiculoMarchamo.Salida.EditarVehiculoMarchamo();

            try
            {
                respuesta = oLnVehiculoMarchamo.EditarVehiculoMarchamo(pDatos);
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
