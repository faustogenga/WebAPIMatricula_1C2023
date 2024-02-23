namespace UI.WebMatricula1C2023.Models.Profesor.Salida
{
    public class VerTodosProfesores : General.RespuestaAPI
    {
        public List<DatosProfesor> ListaProfesores { get; set; }

        public VerTodosProfesores()
        {
            ListaProfesores = new List<DatosProfesor>();
        }
    }

    public class DatosProfesor
    {
        public int Codigo { get; set; }
        public string Identificacion { get; set; }
        public string NombreProfesor { get; set; }
        public string CorreoElectronico { get; set; }
        public string CarreraProfesional { get; set; }
    }
}
