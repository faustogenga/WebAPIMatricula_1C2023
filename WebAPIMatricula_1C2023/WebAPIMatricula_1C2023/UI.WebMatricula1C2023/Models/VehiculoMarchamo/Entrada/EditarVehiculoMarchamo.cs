namespace UI.WebMatricula1C2023.Models.VehiculoMarchamo.Entrada
{
    public class EditarVehiculoMarchamo : General.EntradaAPI
    {
        public int Codigo { get; set; }
        public string NombreCompleto { get; set; }
        public string PlacaVehiculo { get; set; }
        public string ModeloVehiculo { get; set; }
        public string ColorVehiculo { get; set; }
    }
}
