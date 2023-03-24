﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dto.Carrera.Salida
{
    public class VerTodasCarreras : General.RespuestaAPI
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
