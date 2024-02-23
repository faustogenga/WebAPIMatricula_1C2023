namespace UI.WebMatricula1C2023.Models.Carrera.Salida
{
    public class VerTodasCarreras
    {
        public List<DatosCarrera> ListaCarreras { get; set; }

        public VerTodasCarreras()
        {
            ListaCarreras = new List<DatosCarrera>();
        }
    }

    public class DatosCarrera
    {
        public int Codigo { get; set; }
        public string Carrera { get; set; }
        public string Sede { get; set; }
        public int Cuatrimestres { get; set; }
        public string Idioma { get; set; }
        public int MateriasMatriculadas { get; set; }
    }
}
