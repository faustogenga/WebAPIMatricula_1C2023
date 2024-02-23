using Api.Bll.Estudiante.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Bll.Estudiante
{
    /// <summary>
    /// Esta clase es la logica de negocios de Estudiante
    /// </summary>
    public class LnEstudiante
    {
        private IAdEstudiante adEstudiante;

        public LnEstudiante(IAdEstudiante accesoDatosEstudiante)
        {
            this.adEstudiante = accesoDatosEstudiante;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pInformacion"></param>
        /// <returns></returns>
        public Api.Dto.Estudiante.Salida.VerTodosEstudiantes VerTodosEstudiantes(Dto.Estudiante.Entrada.VerTodosEstudiantes pInformacion)
        {
            Api.Dto.Estudiante.Salida.VerTodosEstudiantes respuesta = new Api.Dto.Estudiante.Salida.VerTodosEstudiantes();

            try
            {
                respuesta = adEstudiante.VerTodosEstudiantes();
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public Dto.Estudiante.Salida.VerDetalleEstudiante VerDetalleEstudiante(Dto.Estudiante.Entrada.VerDetalleEstudiante pInformacion)
        {
            Api.Dto.Estudiante.Salida.VerDetalleEstudiante respuesta = new Dto.Estudiante.Salida.VerDetalleEstudiante();

            try
            {
                respuesta = adEstudiante.VerDetalleEstudiante(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public Api.Dto.Estudiante.Salida.AgregarEstudiante AgregarEstudiante(Dto.Estudiante.Entrada.AgregarEstudiante pInformacion)
        {
            Api.Dto.Estudiante.Salida.AgregarEstudiante respuesta = new Api.Dto.Estudiante.Salida.AgregarEstudiante();

            try
            {
                respuesta = adEstudiante.AgregarEstudiante(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public Dto.Estudiante.Salida.EditarEstudiante EditarEstudiante(Dto.Estudiante.Entrada.EditarEstudiante pInformacion)
        {
            Api.Dto.Estudiante.Salida.EditarEstudiante respuesta = new Api.Dto.Estudiante.Salida.EditarEstudiante();

            try
            {
                Api.Dto.Estudiante.Entrada.VerDetalleEstudiante entradaVerDetalleEstudiante = new Api.Dto.Estudiante.Entrada.VerDetalleEstudiante();
                entradaVerDetalleEstudiante.Codigo = pInformacion.Codigo;
                Api.Dto.Estudiante.Salida.VerDetalleEstudiante detalleTrader = adEstudiante.VerDetalleEstudiante(entradaVerDetalleEstudiante);

                respuesta = adEstudiante.EditarEstudiante(pInformacion);

            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }
        public Dto.Estudiante.Salida.EliminarEstudiante EliminarEstudiante(Dto.Estudiante.Entrada.EliminarEstudiante pInformacion)
        {
            Api.Dto.Estudiante.Salida.EliminarEstudiante respuesta = new Dto.Estudiante.Salida.EliminarEstudiante();

            try
            {
                respuesta = adEstudiante.EliminarEstudiante(pInformacion);

            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }
    }
}
