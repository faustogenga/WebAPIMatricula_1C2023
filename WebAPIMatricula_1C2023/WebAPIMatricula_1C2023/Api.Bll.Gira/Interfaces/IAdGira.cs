using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Bll.Gira.Interfaces
{
    public interface IAdGira
    {
        Api.Dto.Gira.Salida.VerTodasGiras VerTodasGiras();
        Api.Dto.Gira.Salida.VerDetalleGira VerDetalleGira(Api.Dto.Gira.Entrada.VerDetalleGira pInformacion);
        Api.Dto.Gira.Salida.AgregarGira AgregarGira(Api.Dto.Gira.Entrada.AgregarGira pInformacion);
        Api.Dto.Gira.Salida.EditarGira EditarGira(Api.Dto.Gira.Entrada.EditarGira pInformacion);
        Api.Dto.Gira.Salida.EliminarGira EliminarGira(Api.Dto.Gira.Entrada.EliminarGira pInformacion);
    }
}
