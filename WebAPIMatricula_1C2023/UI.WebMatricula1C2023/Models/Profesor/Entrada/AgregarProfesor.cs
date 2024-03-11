
namespace UI.WebMatricula1C2023.Models.Profesor.Entrada
{

    public class AgregarProfesor : General.EntradaAPI
    {
        public string Identificacion { get; set; }
        public string NombreProfesor { get; set; }
        public string CorreoElectronico { get; set; }
        public string CarreraProfesional { get; set; }
    }
}
