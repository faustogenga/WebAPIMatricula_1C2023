using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dto.Curso.Salida
{
    public class VerTodosCursos : General.RespuestaAPI
    {
        public List<DatosCurso> ListaCursos { get; set; }

        public VerTodosCursos()
        {
            ListaCursos = new List<DatosCurso>();
        }
    }

    public class DatosCurso
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public string Horario { get; set; }
        public int Cupo { get; set; }
        public string Estado { get; set; }
    }
}
