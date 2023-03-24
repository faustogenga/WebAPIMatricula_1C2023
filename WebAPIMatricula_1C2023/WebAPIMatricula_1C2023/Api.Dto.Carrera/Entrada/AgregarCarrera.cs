using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dto.Carrera.Entrada
{
    public class AgregarCarrera : General.EntradaAPI
    {
        
        public string Carrera { get; set; }
        public string Sede { get; set; }
        public int Cuatrimestres { get; set; }
        public string Idioma { get; set; }
        public int MateriasMatriculadas { get; set; }
      
    }
}
