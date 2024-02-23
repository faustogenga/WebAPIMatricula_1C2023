namespace UI.WebMatricula1C2023.Models.Estudiante.Salida
{
    public class EditarEstudiante : General.RespuestaAPI
    {
        public int Codigo { get; set; }
        public string Identificacion { get; set; }
        public string NombreCompleto { get; set; }
        public string CorreoElectronico { get; set; }
        public string Estado { get; set; }
    }
}
