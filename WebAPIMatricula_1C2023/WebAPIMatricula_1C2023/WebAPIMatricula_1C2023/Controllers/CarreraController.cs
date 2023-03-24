using Api.Bll.Carrera;
using Api.Bll.Carrera.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIMatricula_1C2023.Controllers
{
    [Route("Api/v1" + "/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class CarreraController : Controller
    {
        private LnCarrera oLnCarrera;

        public CarreraController(IAdCarrera accesoAdCarrera)
        {
            oLnCarrera = new LnCarrera(accesoAdCarrera);
        }

        [HttpPost]
        [Route("AgregarCarrera")]
        public IActionResult AgregarCarrera([FromBody] Api.Dto.Carrera.Entrada.AgregarCarrera pDatos)
        {
            Api.Dto.Carrera.Salida.AgregarCarrera respuesta = new Api.Dto.Carrera.Salida.AgregarCarrera();
            try
            {
                respuesta = oLnCarrera.AgregarCarrera(pDatos);
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
        [Route("VerTodasCarreras")]
        public IActionResult VerTodasCarreras(Api.Dto.Carrera.Entrada.VerTodasCarreras pDatos)
        {
            Api.Dto.Carrera.Salida.VerTodasCarreras respuesta = new Api.Dto.Carrera.Salida.VerTodasCarreras();

            try
            {
                respuesta = oLnCarrera.VerTodasCarreras(pDatos);
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
        [Route("EliminarCarrera")]
        public IActionResult EliminarCarrera([FromBody] Api.Dto.Carrera.Entrada.EliminarCarrera pDatos)
        {
            Api.Dto.Carrera.Salida.EliminarCarrera respuesta = new Api.Dto.Carrera.Salida.EliminarCarrera();

            try
            {
                respuesta = oLnCarrera.EliminarCarrera(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }


        [HttpPost]
        [Route("VerDetalleCarrera")]
        public IActionResult VerDetalleCarrera([FromBody] Api.Dto.Carrera.Entrada.VerDetalleCarrera pDatos)
        {
            Api.Dto.Carrera.Salida.VerDetalleCarrera respuesta = new Api.Dto.Carrera.Salida.VerDetalleCarrera();

            try
            {
                respuesta = oLnCarrera.VerDetalleCarrera(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }

        [HttpPost]
        [Route("EditarCarrera")]
        public IActionResult EditarCarrera([FromBody] Api.Dto.Carrera.Entrada.EditarCarrera pDatos)
        {
            Api.Dto.Carrera.Salida.EditarCarrera respuesta = new Api.Dto.Carrera.Salida.EditarCarrera();

            try
            {
                respuesta = oLnCarrera.EditarCarrera(pDatos);
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
