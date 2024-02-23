using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Bll.Estudiante.Interfaces
{
    public interface IAdEstudiante
    {
        Api.Dto.Estudiante.Salida.VerTodosEstudiantes VerTodosEstudiantes();
        Api.Dto.Estudiante.Salida.VerDetalleEstudiante VerDetalleEstudiante(Api.Dto.Estudiante.Entrada.VerDetalleEstudiante pInformacion);
        Api.Dto.Estudiante.Salida.AgregarEstudiante AgregarEstudiante(Api.Dto.Estudiante.Entrada.AgregarEstudiante pInformacion);
        Api.Dto.Estudiante.Salida.EditarEstudiante EditarEstudiante(Api.Dto.Estudiante.Entrada.EditarEstudiante pInformacion);
        Api.Dto.Estudiante.Salida.EliminarEstudiante EliminarEstudiante(Api.Dto.Estudiante.Entrada.EliminarEstudiante pInformacion);
    }
}
