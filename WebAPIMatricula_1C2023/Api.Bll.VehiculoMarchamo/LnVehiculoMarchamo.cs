using Api.Bll.VehiculoMarchamo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Bll.VehiculoMarchamo
{
    public class LnVehiculoMarchamo
    {
        private IAdVehiculoMarchamo adVehiculoMarchamo;

        public LnVehiculoMarchamo(IAdVehiculoMarchamo accesoDatosVehiculoMarchamo)
        {
            this.adVehiculoMarchamo= accesoDatosVehiculoMarchamo;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pInformacion"></param>
        /// <returns></returns>
        public Api.Dto.VehiculoMarchamo.Salida.VerTodosVehiculoMarchamos VerTodosVehiculoMarchamos(Dto.VehiculoMarchamo.Entrada.VerTodosVehiculoMarchamos pInformacion)
        {
            Api.Dto.VehiculoMarchamo.Salida.VerTodosVehiculoMarchamos respuesta = new Api.Dto.VehiculoMarchamo.Salida.VerTodosVehiculoMarchamos();

            try
            {
                respuesta = adVehiculoMarchamo.VerTodosVehiculoMarchamos();
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public Dto.VehiculoMarchamo.Salida.VerDetalleVehiculoMarchamo VerDetalleVehiculoMarchamo(Dto.VehiculoMarchamo.Entrada.VerDetalleVehiculoMarchamo pInformacion)
        {
            Api.Dto.VehiculoMarchamo.Salida.VerDetalleVehiculoMarchamo respuesta = new Dto.VehiculoMarchamo.Salida.VerDetalleVehiculoMarchamo();

            try
            {
                respuesta = adVehiculoMarchamo.VerDetalleVehiculoMarchamo(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public Api.Dto.VehiculoMarchamo.Salida.AgregarVehiculoMarchamo AgregarVehiculoMarchamo(Dto.VehiculoMarchamo.Entrada.AgregarVehiculoMarchamo pInformacion)
        {
            Api.Dto.VehiculoMarchamo.Salida.AgregarVehiculoMarchamo respuesta = new Api.Dto.VehiculoMarchamo.Salida.AgregarVehiculoMarchamo();

            try
            {
                respuesta = adVehiculoMarchamo.AgregarVehiculoMarchamo(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public Dto.VehiculoMarchamo.Salida.EditarVehiculoMarchamo EditarVehiculoMarchamo(Dto.VehiculoMarchamo.Entrada.EditarVehiculoMarchamo pInformacion)
        {
            Api.Dto.VehiculoMarchamo.Salida.EditarVehiculoMarchamo respuesta = new Api.Dto.VehiculoMarchamo.Salida.EditarVehiculoMarchamo();

            try
            {
                Api.Dto.VehiculoMarchamo.Entrada.VerDetalleVehiculoMarchamo entradaVerDetalleVehiculoMarchamo = new Api.Dto.VehiculoMarchamo.Entrada.VerDetalleVehiculoMarchamo();
                entradaVerDetalleVehiculoMarchamo.Codigo = pInformacion.Codigo;
                Api.Dto.VehiculoMarchamo.Salida.VerDetalleVehiculoMarchamo detalleTrader = adVehiculoMarchamo.VerDetalleVehiculoMarchamo(entradaVerDetalleVehiculoMarchamo);

                respuesta = adVehiculoMarchamo.EditarVehiculoMarchamo(pInformacion);

            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }
        public Dto.VehiculoMarchamo.Salida.EliminarVehiculoMarchamo EliminarVehiculoMarchamo(Dto.VehiculoMarchamo.Entrada.EliminarVehiculoMarchamo pInformacion)
        {
            Api.Dto.VehiculoMarchamo.Salida.EliminarVehiculoMarchamo respuesta = new Dto.VehiculoMarchamo.Salida.EliminarVehiculoMarchamo();

            try
            {
                respuesta = adVehiculoMarchamo.EliminarVehiculoMarchamo(pInformacion);

            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }
    }
}
