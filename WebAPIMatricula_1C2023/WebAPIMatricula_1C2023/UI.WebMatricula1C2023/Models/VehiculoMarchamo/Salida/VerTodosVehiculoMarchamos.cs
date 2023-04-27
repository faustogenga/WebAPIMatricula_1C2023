namespace UI.WebMatricula1C2023.Models.VehiculoMarchamo.Salida
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
