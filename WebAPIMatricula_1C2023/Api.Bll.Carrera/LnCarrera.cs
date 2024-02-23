using Api.Bll.Carrera.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Bll.Carrera
{
    public class LnCarrera
    {
        private IAdCarrera adCarrera;

        public LnCarrera(IAdCarrera accesoDatosCarrera)
        {
            this.adCarrera = accesoDatosCarrera;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pInformacion"></param>
        /// <returns></returns>
        public Api.Dto.Carrera.Salida.VerTodasCarreras VerTodasCarreras(Dto.Carrera.Entrada.VerTodasCarreras pInformacion)
        {
            Api.Dto.Carrera.Salida.VerTodasCarreras respuesta = new Api.Dto.Carrera.Salida.VerTodasCarreras();

            try
            {
                respuesta = adCarrera.VerTodasCarreras();
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public Dto.Carrera.Salida.VerDetalleCarrera VerDetalleCarrera(Dto.Carrera.Entrada.VerDetalleCarrera pInformacion)
        {
            Api.Dto.Carrera.Salida.VerDetalleCarrera respuesta = new Dto.Carrera.Salida.VerDetalleCarrera();

            try
            {
                respuesta = adCarrera.VerDetalleCarrera(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public Api.Dto.Carrera.Salida.AgregarCarrera AgregarCarrera(Dto.Carrera.Entrada.AgregarCarrera pInformacion)
        {
            Api.Dto.Carrera.Salida.AgregarCarrera respuesta = new Api.Dto.Carrera.Salida.AgregarCarrera();

            try
            {
                respuesta = adCarrera.AgregarCarrera(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public Dto.Carrera.Salida.EditarCarrera EditarCarrera(Dto.Carrera.Entrada.EditarCarrera pInformacion)
        {
            Api.Dto.Carrera.Salida.EditarCarrera respuesta = new Api.Dto.Carrera.Salida.EditarCarrera();

            try
            {
                Api.Dto.Carrera.Entrada.VerDetalleCarrera entradaVerDetalleCarrera = new Api.Dto.Carrera.Entrada.VerDetalleCarrera();
                entradaVerDetalleCarrera.Codigo = pInformacion.Codigo;
                Api.Dto.Carrera.Salida.VerDetalleCarrera detalleTrader = adCarrera.VerDetalleCarrera(entradaVerDetalleCarrera);

                respuesta = adCarrera.EditarCarrera(pInformacion);

            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }
        public Dto.Carrera.Salida.EliminarCarrera EliminarCarrera(Dto.Carrera.Entrada.EliminarCarrera pInformacion)
        {
            Api.Dto.Carrera.Salida.EliminarCarrera respuesta = new Dto.Carrera.Salida.EliminarCarrera();

            try
            {
                respuesta = adCarrera.EliminarCarrera(pInformacion);

            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }
    }
}
