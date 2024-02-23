using Api.Bll.Profesor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Bll.Profesor
{
    public class LnProfesor
    {
        private IAdProfesor adProfesor;

        public LnProfesor(IAdProfesor accesoDatosVehiculoMarchamo)
        {
            this.adProfesor= accesoDatosVehiculoMarchamo;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pInformacion"></param>
        /// <returns></returns>
        public Api.Dto.Profesor.Salida.VerTodosProfesores VerTodosProfesores(Dto.Profesor.Entrada.VerTodosProfesores pInformacion)
        {
            Api.Dto.Profesor.Salida.VerTodosProfesores respuesta = new Api.Dto.Profesor.Salida.VerTodosProfesores();

            try
            {
                respuesta = adProfesor.VerTodosProfesores();
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public Dto.Profesor.Salida.VerDetalleProfesor VerDetalleProfesor(Dto.Profesor.Entrada.VerDetalleProfesor pInformacion)
        {
            Api.Dto.Profesor.Salida.VerDetalleProfesor respuesta = new Dto.Profesor.Salida.VerDetalleProfesor();

            try
            {
                respuesta = adProfesor.VerDetalleProfesor(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public Api.Dto.Profesor.Salida.AgregarProfesor AgregarProfesor(Dto.Profesor.Entrada.AgregarProfesor pInformacion)
        {
            Api.Dto.Profesor.Salida.AgregarProfesor respuesta = new Api.Dto.Profesor.Salida.AgregarProfesor();

            try
            {
                respuesta = adProfesor.AgregarProfesor(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public Dto.Profesor.Salida.EditarProfesor EditarProfesor(Dto.Profesor.Entrada.EditarProfesor pInformacion)
        {
            Api.Dto.Profesor.Salida.EditarProfesor respuesta = new Api.Dto.Profesor.Salida.EditarProfesor();

            try
            {
                Api.Dto.Profesor.Entrada.VerDetalleProfesor entradaVerDetalleProfesor = new Api.Dto.Profesor.Entrada.VerDetalleProfesor();
                entradaVerDetalleProfesor.Codigo = pInformacion.Codigo;
                Api.Dto.Profesor.Salida.VerDetalleProfesor detalleTrader = adProfesor.VerDetalleProfesor(entradaVerDetalleProfesor);

                respuesta = adProfesor.EditarProfesor(pInformacion);

            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }
        public Dto.Profesor.Salida.EliminarProfesor EliminarProfesor(Dto.Profesor.Entrada.EliminarProfesor pInformacion)
        {
            Api.Dto.Profesor.Salida.EliminarProfesor respuesta = new Dto.Profesor.Salida.EliminarProfesor();

            try
            {
                respuesta = adProfesor.EliminarProfesor(pInformacion);

            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }
    }
}
