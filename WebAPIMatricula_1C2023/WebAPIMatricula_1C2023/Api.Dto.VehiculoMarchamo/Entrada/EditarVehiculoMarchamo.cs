﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dto.VehiculoMarchamo.Entrada
{
    public class EditarVehiculoMarchamo : General.EntradaAPI
    {
        public int Codigo { get; set; }
        public string NombreCompleto { get; set; }
        public string PlacaVehiculo { get; set; }
        public string ModeloVehiculo { get; set; }
        public string ColorVehiculo { get; set; }
    }
}
