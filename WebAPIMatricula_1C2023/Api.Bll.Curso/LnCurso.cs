using Api.Bll.Curso.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Bll.Curso
{
    public class LnCurso
    {
        private IAdCurso adCurso;

        public LnCurso(IAdCurso accesoDatosCurso)
        {
            this.adCurso = accesoDatosCurso;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pInformacion"></param>
        /// <returns></returns>
        public Api.Dto.Curso.Salida.VerTodosCursos VerTodosCursos(Dto.Curso.Entrada.VerTodosCursos pInformacion)
        {
            Api.Dto.Curso.Salida.VerTodosCursos respuesta = new Api.Dto.Curso.Salida.VerTodosCursos();

            try
            {
                respuesta = adCurso.VerTodosCursos();
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public Dto.Curso.Salida.VerDetalleCurso VerDetalleCurso(Dto.Curso.Entrada.VerDetalleCurso pInformacion)
        {
            Api.Dto.Curso.Salida.VerDetalleCurso respuesta = new Dto.Curso.Salida.VerDetalleCurso();

            try
            {
                respuesta = adCurso.VerDetalleCurso(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public Api.Dto.Curso.Salida.AgregarCurso AgregarCurso(Dto.Curso.Entrada.AgregarCurso pInformacion)
        {
            Api.Dto.Curso.Salida.AgregarCurso respuesta = new Api.Dto.Curso.Salida.AgregarCurso();

            try
            {
                respuesta = adCurso.AgregarCurso(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public Dto.Curso.Salida.EditarCurso EditarCurso(Dto.Curso.Entrada.EditarCurso pInformacion)
        {
            Api.Dto.Curso.Salida.EditarCurso respuesta = new Api.Dto.Curso.Salida.EditarCurso();

            try
            {
                Api.Dto.Curso.Entrada.VerDetalleCurso entradaVerDetalleCurso = new Api.Dto.Curso.Entrada.VerDetalleCurso();
                entradaVerDetalleCurso.Codigo = pInformacion.Codigo;
                Api.Dto.Curso.Salida.VerDetalleCurso detalleTrader = adCurso.VerDetalleCurso(entradaVerDetalleCurso);

                respuesta = adCurso.EditarCurso(pInformacion);

            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }
        public Dto.Curso.Salida.EliminarCurso EliminarCurso(Dto.Curso.Entrada.EliminarCurso pInformacion)
        {
            Api.Dto.Curso.Salida.EliminarCurso respuesta = new Dto.Curso.Salida.EliminarCurso();

            try
            {
                respuesta = adCurso.EliminarCurso(pInformacion);

            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }
    }
}
