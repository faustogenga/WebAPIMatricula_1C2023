using Api.Bll.Gira.Interfaces;
using Api.Bll.Gira;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIMatricula_1C2023.Controllers
{

    [Route("Api/v1" + "/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class GiraController : Controller
    {
        private LnGira oLnGira;

        public GiraController(IAdGira accesoAdGira)
        {
            oLnGira = new LnGira(accesoAdGira);
        }

        [HttpPost]
        [Route("AgregarGira")]
        public IActionResult AgregarGira([FromBody] Api.Dto.Gira.Entrada.AgregarGira pDatos)
        {
            Api.Dto.Gira.Salida.AgregarGira respuesta = new Api.Dto.Gira.Salida.AgregarGira();
            try
            {
                respuesta = oLnGira.AgregarGira(pDatos);
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
        [Route("VerTodasGiras")]

        public IActionResult VerTodasGiras(Api.Dto.Gira.Entrada.VerTodasGiras pDatos)
        {
            Api.Dto.Gira.Salida.VerTodasGiras respuesta = new Api.Dto.Gira.Salida.VerTodasGiras();

            try
            {
                respuesta = oLnGira.VerTodasGiras(pDatos);
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
        [Route("EliminarGira")]
        public IActionResult EliminarGira([FromBody] Api.Dto.Gira.Entrada.EliminarGira pDatos)
        {
            Api.Dto.Gira.Salida.EliminarGira respuesta = new Api.Dto.Gira.Salida.EliminarGira();

            try
            {
                respuesta = oLnGira.EliminarGira(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }


        [HttpPost]
        [Route("VerDetalleGira")]
        public IActionResult VerDetalleGira([FromBody] Api.Dto.Gira.Entrada.VerDetalleGira pDatos)
        {
            Api.Dto.Gira.Salida.VerDetalleGira respuesta = new Api.Dto.Gira.Salida.VerDetalleGira();

            try
            {
                respuesta = oLnGira.VerDetalleGira(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }

        [HttpPost]
        [Route("EditarGira")]
        public IActionResult EditarGira([FromBody] Api.Dto.Gira.Entrada.EditarGira pDatos)
        {
            Api.Dto.Gira.Salida.EditarGira respuesta = new Api.Dto.Gira.Salida.EditarGira();

            try
            {
                respuesta = oLnGira.EditarGira(pDatos);
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
