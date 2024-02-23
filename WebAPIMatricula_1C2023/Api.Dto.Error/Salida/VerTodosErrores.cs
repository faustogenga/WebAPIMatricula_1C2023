using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dto.Error.Salida
{
    public class VerTodosErrores : General.RespuestaAPI
    {
        public List<DatosError> ListaErrores { get; set; }

        public VerTodosErrores()
        {
            ListaErrores = new List<DatosError>();
        }
    }
    public class DatosError
    {
        public int Codigo { get; set; }
        public int CodigoUsuario { get; set; }
        public DateTime FechaHora { get; set; }
        public string Modulo { get; set; }
        public string Clase { get; set; }
        public string Metodo { get; set; }
        public string Fuente { get; set; }
        public int Numero { get; set; }
        public string Excepcion { get; set; }
    }

}
