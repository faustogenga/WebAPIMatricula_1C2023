using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Bll.VehiculoMarchamo.Interfaces
{
    public interface IAdVehiculoMarchamo
    {
        Api.Dto.VehiculoMarchamo.Salida.VerTodosVehiculoMarchamos VerTodosVehiculoMarchamos();
        Api.Dto.VehiculoMarchamo.Salida.VerDetalleVehiculoMarchamo VerDetalleVehiculoMarchamo(Api.Dto.VehiculoMarchamo.Entrada.VerDetalleVehiculoMarchamo pInformacion);
        Api.Dto.VehiculoMarchamo.Salida.AgregarVehiculoMarchamo AgregarVehiculoMarchamo(Api.Dto.VehiculoMarchamo.Entrada.AgregarVehiculoMarchamo pInformacion);
        Api.Dto.VehiculoMarchamo.Salida.EditarVehiculoMarchamo EditarVehiculoMarchamo(Api.Dto.VehiculoMarchamo.Entrada.EditarVehiculoMarchamo pInformacion);
        Api.Dto.VehiculoMarchamo.Salida.EliminarVehiculoMarchamo EliminarVehiculoMarchamo(Api.Dto.VehiculoMarchamo.Entrada.EliminarVehiculoMarchamo pInformacion);
    }
}
