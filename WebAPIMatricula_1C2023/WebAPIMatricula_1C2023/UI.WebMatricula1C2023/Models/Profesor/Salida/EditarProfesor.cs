namespace UI.WebMatricula1C2023.Models.Profesor.Salida
{
    public class EditarProfesor : General.RespuestaAPI
    {
        public int Codigo { get; set; }
        public string Identificacion { get; set; }
        public string NombreProfesor { get; set; }
        public string CorreoElectronico { get; set; }
        public string CarreraProfesional { get; set; }
    }
}
