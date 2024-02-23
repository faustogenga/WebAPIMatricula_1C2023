using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Bll.Club.Interfaces
{
    public interface IAdClub
    {
        Api.Dto.Club.Salida.VerTodosClubes VerTodosClubes();
        Api.Dto.Club.Salida.VerDetalleClub VerDetalleClub(Api.Dto.Club.Entrada.VerDetalleClub pInformacion);
        Api.Dto.Club.Salida.AgregarClub AgregarClub(Api.Dto.Club.Entrada.AgregarClub pInformacion);
        Api.Dto.Club.Salida.EditarClub EditarClub(Api.Dto.Club.Entrada.EditarClub pInformacion);
        Api.Dto.Club.Salida.EliminarClub EliminarClub(Api.Dto.Club.Entrada.EliminarClub pInformacion);

    }
}
