namespace UI.WebMatricula1C2023.Models.Gira.Entrada
{
    public class AgregarGira : General.EntradaAPI
    {
        public string CodigoGira { get; set; }
        public string Organizacion { get; set; }
        public string Carreras { get; set; }
        public string Fecha { get; set; }
        public string HoraSalida { get; set; }
        public string HoraRegreso { get; set; }
        public string Tipo { get; set; }
    }
}
