namespace UI.WebMatricula1C2023.Models.VehiculoMarchamo.Salida
{
    public class EditarVehiculoMarchamo : General.RespuestaAPI
    {
        public int Codigo { get; set; }
        public string NombreCompleto { get; set; }
        public string PlacaVehiculo { get; set; }
        public string ModeloVehiculo { get; set; }
        public string ColorVehiculo { get; set; }
    }
}
