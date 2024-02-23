using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Bll.Carrera.Interfaces
{
    public interface IAdCarrera
    {
        Api.Dto.Carrera.Salida.VerTodasCarreras VerTodasCarreras();
        Api.Dto.Carrera.Salida.VerDetalleCarrera VerDetalleCarrera(Api.Dto.Carrera.Entrada.VerDetalleCarrera pInformacion);
        Api.Dto.Carrera.Salida.AgregarCarrera AgregarCarrera(Api.Dto.Carrera.Entrada.AgregarCarrera pInformacion);
        Api.Dto.Carrera.Salida.EditarCarrera EditarCarrera(Api.Dto.Carrera.Entrada.EditarCarrera pInformacion);
        Api.Dto.Carrera.Salida.EliminarCarrera EliminarCarrera(Api.Dto.Carrera.Entrada.EliminarCarrera pInformacion);
    }
}
