using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Bll.Profesor.Interfaces
{
    public interface IAdProfesor
    {
        Api.Dto.Profesor.Salida.VerTodosProfesores VerTodosProfesores();
        Api.Dto.Profesor.Salida.VerDetalleProfesor VerDetalleProfesor(Api.Dto.Profesor.Entrada.VerDetalleProfesor pInformacion);
        Api.Dto.Profesor.Salida.AgregarProfesor AgregarProfesor(Api.Dto.Profesor.Entrada.AgregarProfesor pInformacion);
        Api.Dto.Profesor.Salida.EditarProfesor EditarProfesor(Api.Dto.Profesor.Entrada.EditarProfesor pInformacion);
        Api.Dto.Profesor.Salida.EliminarProfesor EliminarProfesor(Api.Dto.Profesor.Entrada.EliminarProfesor pInformacion);
    }
}
