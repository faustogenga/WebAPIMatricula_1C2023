using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dto.Profesor.Entrada
{

    public class AgregarProfesor : General.EntradaAPI
    {
        public string Identificacion { get; set; }
        public string NombreProfesor { get; set; }
        public string CorreoElectronico { get; set; }
        public string CarreraProfesional { get; set; }
    }
}
