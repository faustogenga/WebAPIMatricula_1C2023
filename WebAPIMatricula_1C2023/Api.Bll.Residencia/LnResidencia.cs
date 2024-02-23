using Api.Bll.Residencia.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Bll.Residencia
{
    public class LnResidencia
    {
        private IAdResidencia adResidencia;

        public LnResidencia(IAdResidencia accesoDatosResidencia)
        {
            this.adResidencia = accesoDatosResidencia;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pInformacion"></param>
        /// <returns></returns>
        public Api.Dto.Residencia.Salida.VerTodasResidencias VerTodasResidencias(Dto.Residencia.Entrada.VerTodasResidencias pInformacion)
        {
            Api.Dto.Residencia.Salida.VerTodasResidencias respuesta = new Api.Dto.Residencia.Salida.VerTodasResidencias();

            try
            {
                respuesta = adResidencia.VerTodasResidencias();
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public Dto.Residencia.Salida.VerDetalleResidencia VerDetalleResidencia(Dto.Residencia.Entrada.VerDetalleResidencia pInformacion)
        {
            Api.Dto.Residencia.Salida.VerDetalleResidencia respuesta = new Dto.Residencia.Salida.VerDetalleResidencia();

            try
            {
                respuesta = adResidencia.VerDetalleResidencia(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public Api.Dto.Residencia.Salida.AgregarResidencia AgregarResidencia(Dto.Residencia.Entrada.AgregarResidencia pInformacion)
        {
            Api.Dto.Residencia.Salida.AgregarResidencia respuesta = new Api.Dto.Residencia.Salida.AgregarResidencia();

            try
            {
                respuesta = adResidencia.AgregarResidencia(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public Dto.Residencia.Salida.EditarResidencia EditarResidencia(Dto.Residencia.Entrada.EditarResidencia pInformacion)
        {
            Api.Dto.Residencia.Salida.EditarResidencia respuesta = new Api.Dto.Residencia.Salida.EditarResidencia();

            try
            {
                Api.Dto.Residencia.Entrada.VerDetalleResidencia entradaVerDetalleResidencia = new Api.Dto.Residencia.Entrada.VerDetalleResidencia();
                entradaVerDetalleResidencia.Codigo = pInformacion.Codigo;
                Api.Dto.Residencia.Salida.VerDetalleResidencia detalleTrader = adResidencia.VerDetalleResidencia(entradaVerDetalleResidencia);

                respuesta = adResidencia.EditarResidencia(pInformacion);

            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }
        public Dto.Residencia.Salida.EliminarResidencia EliminarResidencia(Dto.Residencia.Entrada.EliminarResidencia pInformacion)
        {
            Api.Dto.Residencia.Salida.EliminarResidencia respuesta = new Dto.Residencia.Salida.EliminarResidencia();

            try
            {
                respuesta = adResidencia.EliminarResidencia(pInformacion);

            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }
    }
}
