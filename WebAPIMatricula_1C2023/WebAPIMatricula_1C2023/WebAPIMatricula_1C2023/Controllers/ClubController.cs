using Api.Bll.Club.Interfaces;
using Api.Bll.Club;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIMatricula_1C2023.Controllers
{

    [Route("Api/v1" + "/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class ClubController : Controller
    {
        private LnClub oLnClub;

        public ClubController(IAdClub accesoAdClub)
        {
            oLnClub = new LnClub(accesoAdClub);
        }

        [HttpPost]
        [Route("AgregarClub")]
        public IActionResult AgregarClub([FromBody] Api.Dto.Club.Entrada.AgregarClub pDatos)
        {
            Api.Dto.Club.Salida.AgregarClub respuesta = new Api.Dto.Club.Salida.AgregarClub();
            try
            {
                respuesta = oLnClub.AgregarClub(pDatos);
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
        [Route("VerTodosClubes")]
        public IActionResult VerTodosClubes(Api.Dto.Club.Entrada.VerTodosClubes pDatos)
        {
            Api.Dto.Club.Salida.VerTodosClubes respuesta = new Api.Dto.Club.Salida.VerTodosClubes();

            try
            {
                respuesta = oLnClub.VerTodosClubes(pDatos);
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
        [Route("EliminarClub")]
        public IActionResult EliminarClub([FromBody] Api.Dto.Club.Entrada.EliminarClub pDatos)
        {
            Api.Dto.Club.Salida.EliminarClub respuesta = new Api.Dto.Club.Salida.EliminarClub();

            try
            {
                respuesta = oLnClub.EliminarClub(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }


        [HttpPost]
        [Route("VerDetalleClub")]
        public IActionResult VerDetalleClub([FromBody] Api.Dto.Club.Entrada.VerDetalleClub pDatos)
        {
            Api.Dto.Club.Salida.VerDetalleClub respuesta = new Api.Dto.Club.Salida.VerDetalleClub();

            try
            {
                respuesta = oLnClub.VerDetalleClub(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }

        [HttpPost]
        [Route("EditarClub")]
        public IActionResult EditarClub([FromBody] Api.Dto.Club.Entrada.EditarClub pDatos)
        {
            Api.Dto.Club.Salida.EditarClub respuesta = new Api.Dto.Club.Salida.EditarClub();

            try
            {
                respuesta = oLnClub.EditarClub(pDatos);
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
