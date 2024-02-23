namespace UI.WebMatricula1C2023.Models.Carrera.Entrada
{
    public class VerDetalleCarrera : General.EntradaAPI
    {
        public int Codigo { get; set; }
        public string Carrera { get; set; }
        public string Sede { get; set; }
        public int Cuatrimestres { get; set; }
        public string Idioma { get; set; }
        public int MateriasMatriculadas { get; set; }


    }
}
