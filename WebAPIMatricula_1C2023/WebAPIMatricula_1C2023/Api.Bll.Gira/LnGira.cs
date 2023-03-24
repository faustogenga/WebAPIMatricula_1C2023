using Api.Bll.Gira.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Bll.Gira
{
    public class LnGira
    {
        private IAdGira adGira;

        public LnGira(IAdGira accesoDatosGira)
        {
            this.adGira = accesoDatosGira;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pInformacion"></param>
        /// <returns></returns>
        public Api.Dto.Gira.Salida.VerTodasGiras VerTodasGiras(Dto.Gira.Entrada.VerTodasGiras pInformacion)
        {
            Api.Dto.Gira.Salida.VerTodasGiras respuesta = new Api.Dto.Gira.Salida.VerTodasGiras();

            try
            {
                respuesta = adGira.VerTodasGiras();
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public Dto.Gira.Salida.VerDetalleGira VerDetalleGira(Dto.Gira.Entrada.VerDetalleGira pInformacion)
        {
            Api.Dto.Gira.Salida.VerDetalleGira respuesta = new Dto.Gira.Salida.VerDetalleGira();

            try
            {
                respuesta = adGira.VerDetalleGira(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public Api.Dto.Gira.Salida.AgregarGira AgregarGira(Dto.Gira.Entrada.AgregarGira pInformacion)
        {
            Api.Dto.Gira.Salida.AgregarGira respuesta = new Api.Dto.Gira.Salida.AgregarGira();

            try
            {
                respuesta = adGira.AgregarGira(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public Dto.Gira.Salida.EditarGira EditarGira(Dto.Gira.Entrada.EditarGira pInformacion)
        {
            Api.Dto.Gira.Salida.EditarGira respuesta = new Api.Dto.Gira.Salida.EditarGira();

            try
            {
                Api.Dto.Gira.Entrada.VerDetalleGira entradaVerDetalleGira = new Api.Dto.Gira.Entrada.VerDetalleGira();
                entradaVerDetalleGira.Codigo = pInformacion.Codigo;
                Api.Dto.Gira.Salida.VerDetalleGira detalleTrader = adGira.VerDetalleGira(entradaVerDetalleGira);

                respuesta = adGira.EditarGira(pInformacion);

            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }
        public Dto.Gira.Salida.EliminarGira EliminarGira(Dto.Gira.Entrada.EliminarGira pInformacion)
        {
            Api.Dto.Gira.Salida.EliminarGira respuesta = new Dto.Gira.Salida.EliminarGira();

            try
            {
                respuesta = adGira.EliminarGira(pInformacion);

            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

    }
}
