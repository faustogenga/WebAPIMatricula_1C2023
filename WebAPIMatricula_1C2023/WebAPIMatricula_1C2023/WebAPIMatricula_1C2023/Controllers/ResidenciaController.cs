using Api.Bll.Residencia;
using Api.Bll.Residencia.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebMatricula1C2023.Controllers
{
    [Route("Api/v1" + "/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class ResidenciaController : Controller
    {
        private LnResidencia oLnResidencia;

        public ResidenciaController(IAdResidencia accesoAdResidencia)
        {
            oLnResidencia = new LnResidencia(accesoAdResidencia);
        }

        [HttpPost]
        [Route("AgregarResidencia")]
        public IActionResult AgregarResidencia([FromBody] Api.Dto.Residencia.Entrada.AgregarResidencia pDatos)
        {
            Api.Dto.Residencia.Salida.AgregarResidencia respuesta = new Api.Dto.Residencia.Salida.AgregarResidencia();
            try
            {
                respuesta = oLnResidencia.AgregarResidencia(pDatos);
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
        [Route("VerTodasResidencias")]
        public IActionResult VerTodasResidencias(Api.Dto.Residencia.Entrada.VerTodasResidencias pDatos)
        {
            Api.Dto.Residencia.Salida.VerTodasResidencias respuesta = new Api.Dto.Residencia.Salida.VerTodasResidencias();

            try
            {
                respuesta = oLnResidencia.VerTodasResidencias(pDatos);
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
        [Route("EliminarResidencia")]
        public IActionResult EliminarResidencia([FromBody] Api.Dto.Residencia.Entrada.EliminarResidencia pDatos)
        {
            Api.Dto.Residencia.Salida.EliminarResidencia respuesta = new Api.Dto.Residencia.Salida.EliminarResidencia();

            try
            {
                respuesta = oLnResidencia.EliminarResidencia(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }


        [HttpPost]
        [Route("VerDetalleResidencia")]
        public IActionResult VerDetalleResidencia([FromBody] Api.Dto.Residencia.Entrada.VerDetalleResidencia pDatos)
        {
            Api.Dto.Residencia.Salida.VerDetalleResidencia respuesta = new Api.Dto.Residencia.Salida.VerDetalleResidencia();

            try
            {
                respuesta = oLnResidencia.VerDetalleResidencia(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }

        [HttpPost]
        [Route("EditarResidencia")]
        public IActionResult EditarResidencia([FromBody] Api.Dto.Residencia.Entrada.EditarResidencia pDatos)
        {
            Api.Dto.Residencia.Salida.EditarResidencia respuesta = new Api.Dto.Residencia.Salida.EditarResidencia();

            try
            {
                respuesta = oLnResidencia.EditarResidencia(pDatos);
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
