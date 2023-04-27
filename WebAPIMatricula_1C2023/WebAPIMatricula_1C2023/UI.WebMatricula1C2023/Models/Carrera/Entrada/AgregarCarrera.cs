namespace UI.WebMatricula1C2023.Models.Carrera.Entrada
{
    public class AgregarCarrera : General.EntradaAPI
    {
        public string Carrera { get; set; }
        public string Sede { get; set; }
        public int Cuatrimestres { get; set; }
        public string Idioma { get; set; }
        public int MateriasMatriculadas { get; set; }
    }
}
