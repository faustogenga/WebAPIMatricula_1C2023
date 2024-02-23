namespace UI.WebMatricula1C2023.Models.Gira.Salida
{
    public class EditarGira : General.RespuestaAPI
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
