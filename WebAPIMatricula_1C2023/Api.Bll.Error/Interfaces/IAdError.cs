using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Bll.Error.Interfaces
{
    public interface IAdError
    {
        Api.Dto.Error.Salida.VerTodosErrores VerTodosErrores();
        Api.Dto.Error.Salida.AgregarError AgregarError(Api.Dto.Error.Entrada.AgregarError pInformacion);
    }
}
