namespace UI.WebMatricula1C2023.Models.Residencia.Entrada
{
    public class VerDetalleResidencia : General.EntradaAPI
    {
        public int Codigo { get; set; }
        public int Cedula { get; set; }
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string Canton { get; set; }
        public string DirExacta { get; set; }
    }
}
