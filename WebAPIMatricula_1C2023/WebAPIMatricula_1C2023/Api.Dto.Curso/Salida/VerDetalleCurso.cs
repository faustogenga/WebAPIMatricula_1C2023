using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dto.Curso.Salida
{
    public class VerDetalleCurso : General.RespuestaAPI
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public string Horario { get; set; }
        public int Cupo { get; set; }
        public string Estado { get; set; }
    }
}
