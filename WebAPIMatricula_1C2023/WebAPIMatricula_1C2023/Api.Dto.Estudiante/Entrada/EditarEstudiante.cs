using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dto.Estudiante.Entrada
{
    public class EditarEstudiante : General.EntradaAPI
    {
        public int Codigo { get; set; }
        public string Identificacion { get; set; }
        public string NombreCompleto { get; set; }
        public string CorreoElectronico { get; set; }
        public string Estado { get; set; }
    }
}
