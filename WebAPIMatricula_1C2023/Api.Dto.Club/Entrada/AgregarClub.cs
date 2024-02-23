using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dto.Club.Entrada
{
    public class AgregarClub : General.EntradaAPI
    {
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public string Horario { get; set; }
        public string Ubicacion { get; set; }
        public string Contacto { get; set; }
        public string Encargado { get; set; }
    }
}
