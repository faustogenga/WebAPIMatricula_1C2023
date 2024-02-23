using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dto.Gira.Entrada
{
    public class EditarGira : General.EntradaAPI
    {
        public int Codigo { get; set; }
        public string CodigoGira { get; set; }
        public string Organizacion { get; set; }
        public string Carreras { get; set; }
        public string Fecha { get; set; }
        public string HoraSalida { get; set; }
        public string HoraRegreso { get; set; }
        public string Tipo { get; set; }
    }
}
