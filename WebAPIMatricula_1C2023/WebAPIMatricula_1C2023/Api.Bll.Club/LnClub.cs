using Api.Bll.Club.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Bll.Club
{
    public class LnClub
    {
        private IAdClub adClub;

        public LnClub(IAdClub accesoDatosClub)
        {
            this.adClub = accesoDatosClub;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pInformacion"></param>
        /// <returns></returns>
        public Api.Dto.Club.Salida.VerTodosClubes VerTodosClubes(Dto.Club.Entrada.VerTodosClubes pInformacion)
        {
            Api.Dto.Club.Salida.VerTodosClubes respuesta = new Api.Dto.Club.Salida.VerTodosClubes();

            try
            {
                respuesta = adClub.VerTodosClubes();
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public Dto.Club.Salida.VerDetalleClub VerDetalleClub(Dto.Club.Entrada.VerDetalleClub pInformacion)
        {
            Api.Dto.Club.Salida.VerDetalleClub respuesta = new Dto.Club.Salida.VerDetalleClub();

            try
            {
                respuesta = adClub.VerDetalleClub(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public Api.Dto.Club.Salida.AgregarClub AgregarClub(Dto.Club.Entrada.AgregarClub pInformacion)
        {
            Api.Dto.Club.Salida.AgregarClub respuesta = new Api.Dto.Club.Salida.AgregarClub();

            try
            {
                respuesta = adClub.AgregarClub(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public Dto.Club.Salida.EditarClub EditarClub(Dto.Club.Entrada.EditarClub pInformacion)
        {
            Api.Dto.Club.Salida.EditarClub respuesta = new Api.Dto.Club.Salida.EditarClub();

            try
            {
                Api.Dto.Club.Entrada.VerDetalleClub entradaVerDetalleClub = new Api.Dto.Club.Entrada.VerDetalleClub();
                entradaVerDetalleClub.Codigo = pInformacion.Codigo;
                Api.Dto.Club.Salida.VerDetalleClub detalleTrader = adClub.VerDetalleClub(entradaVerDetalleClub);

                respuesta = adClub.EditarClub(pInformacion);

            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }
        public Dto.Club.Salida.EliminarClub EliminarClub(Dto.Club.Entrada.EliminarClub pInformacion)
        {
            Api.Dto.Club.Salida.EliminarClub respuesta = new Dto.Club.Salida.EliminarClub();

            try
            {
                respuesta = adClub.EliminarClub(pInformacion);

            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }
    }
}
