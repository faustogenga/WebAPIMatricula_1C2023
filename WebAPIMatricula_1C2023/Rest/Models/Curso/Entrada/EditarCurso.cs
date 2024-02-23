namespace UI.WebMatricula1C2023.Models.Curso.Entrada
{
    public class EditarCurso : General.EntradaAPI
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public string Horario { get; set; }
        public int Cupo { get; set; }
        public string Estado { get; set; }
    }
}
