using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dto.General
{
    public class RespuestaAPI
    {
        protected const int CODIGO_ERROR = -1;
        protected const int CODIGO_EXITOSO = 0;

        protected const string TRANSACCION_EXITOSA = "Transacción exitosa";
        protected const string ERROR_APLICACION = "Ocurrió un error la aplicación";

        public int CodigoRespuesta { get; set; }
        public string DetalleRespuesta { get; set; }
        public string DetalleTecnico { get; set; }

        public RespuestaAPI()
        {
            this.CodigoRespuesta = CODIGO_EXITOSO;
            this.DetalleRespuesta = TRANSACCION_EXITOSA;
            this.DetalleTecnico = string.Empty;
        }

        public void setErrorComunicacion(String error)
        {
            this.CodigoRespuesta = CODIGO_ERROR;
            this.DetalleRespuesta = ERROR_APLICACION;
            this.DetalleTecnico = error;
        }
    }
}
