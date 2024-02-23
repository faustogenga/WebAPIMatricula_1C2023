using Api.Bll.Error.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Bll.Error
{
    public class LnError
    {
        private IAdError adError;

        public LnError(IAdError accesoDatosError)
        {
            this.adError = accesoDatosError;
        }

        public Api.Dto.Error.Salida.AgregarError AgregarError(Dto.Error.Entrada.AgregarError pInformacion)
        {
            Api.Dto.Error.Salida.AgregarError respuesta = new Api.Dto.Error.Salida.AgregarError();

            try
            {
                respuesta = adError.AgregarError(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }

        public Api.Dto.Error.Salida.VerTodosErrores VerTodosErrores(Dto.Error.Entrada.VerTodosErrores pInformacion)
        {
            Api.Dto.Error.Salida.VerTodosErrores respuesta = new Api.Dto.Error.Salida.VerTodosErrores();

            try
            {
                respuesta = adError.VerTodosErrores();
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }

            return respuesta;
        }
    }
}
