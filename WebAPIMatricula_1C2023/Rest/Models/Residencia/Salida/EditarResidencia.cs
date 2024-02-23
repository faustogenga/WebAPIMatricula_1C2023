namespace UI.WebMatricula1C2023.Models.Residencia.Salida
{
    public class EditarResidencia : General.RespuestaAPI
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
