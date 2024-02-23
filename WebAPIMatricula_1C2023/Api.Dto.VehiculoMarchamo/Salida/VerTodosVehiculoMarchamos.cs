using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dto.VehiculoMarchamo.Salida
{
    public class VerTodosVehiculoMarchamos : General.RespuestaAPI
    {
        public List<DatosVehiculoMarchamo> ListaVehiculoMarchamos { get; set; }

        public VerTodosVehiculoMarchamos()
        {
            ListaVehiculoMarchamos = new List<DatosVehiculoMarchamo>();
        }
    }

    public class DatosVehiculoMarchamo
    {
        public int Codigo { get; set; }
        public string NombreCompleto { get; set; }
        public string PlacaVehiculo { get; set; }
        public string ModeloVehiculo { get; set; }
        public string ColorVehiculo { get; set; }
    }
}
