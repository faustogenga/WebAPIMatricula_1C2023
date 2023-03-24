namespace UI.WebMatricula1C2023.Models.Estudiante.Entrada
{
    public class AgregarEstudiante : General.EntradaAPI
    {
        public string Identificacion { get; set; }
        public string NombreCompleto { get; set; }
        public string CorreoElectronico { get; set; }
        public string Estado { get; set; }
    }
}
