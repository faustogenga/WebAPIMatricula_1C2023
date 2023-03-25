using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace UI.WebMatricula1C2023.Logica
{
    public class LnCurso
    {
        LnConsumoAPI lnConsumoAPI;

        public LnCurso()
        {
            lnConsumoAPI = new LnConsumoAPI();
        }
        public async Task<Models.Curso.Salida.VerTodosCursos> VerTodosCursos(Models.Curso.Entrada.VerTodosCursos pDatos, string token)
        {
            string encabezado = "Curso/VerTodosCursos";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Curso.Salida.VerTodosCursos>(respuesta);
        }
        public async Task<Models.Curso.Salida.VerDetalleCurso> VerDetalleCurso(Models.Curso.Entrada.VerDetalleCurso pDatos, string token)
        {
            string encabezado = "Curso/VerDetalleCurso";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Curso.Salida.VerDetalleCurso>(respuesta);
        }

        public async Task<Models.Curso.Salida.AgregarCurso> AgregarCurso(Models.Curso.Entrada.AgregarCurso pDatos, string token)
        {
            string encabezado = "Curso/AgregarCurso";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Curso.Salida.AgregarCurso>(respuesta);
        }

        public async Task<Models.Curso.Salida.EditarCurso> EditarCurso(Models.Curso.Entrada.EditarCurso pDatos, string token)
        {
            string encabezado = "Curso/EditarCurso";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Curso.Salida.EditarCurso>(respuesta);
        }

        public async Task<Models.Curso.Salida.EliminarCurso> EliminarCurso(Models.Curso.Entrada.EliminarCurso pDatos, string token)
        {
            string encabezado = "Curso/AgregarCurso";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Curso.Salida.EliminarCurso>(respuesta);
        }

    }
}
