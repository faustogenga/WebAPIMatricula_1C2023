using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dto.Residencia.Salida
{
    public class VerDetalleResidencia : General.RespuestaAPI
    {
        public int Codigo { get; set; }
        public int Cedula { get; set; }
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string Canton { get; set; }
        public string DirExacta { get; set; }
    }
}
