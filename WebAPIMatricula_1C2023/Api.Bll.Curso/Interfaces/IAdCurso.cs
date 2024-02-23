using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Bll.Curso.Interfaces
{
    public interface IAdCurso
    {
        Api.Dto.Curso.Salida.VerTodosCursos VerTodosCursos();
        Api.Dto.Curso.Salida.VerDetalleCurso VerDetalleCurso(Api.Dto.Curso.Entrada.VerDetalleCurso pInformacion);
        Api.Dto.Curso.Salida.AgregarCurso AgregarCurso(Api.Dto.Curso.Entrada.AgregarCurso pInformacion);
        Api.Dto.Curso.Salida.EditarCurso EditarCurso(Api.Dto.Curso.Entrada.EditarCurso pInformacion);
        Api.Dto.Curso.Salida.EliminarCurso EliminarCurso(Api.Dto.Curso.Entrada.EliminarCurso pInformacion);
    }
}
