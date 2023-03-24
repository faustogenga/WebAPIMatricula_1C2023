using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace UI.WebMatricula1C2023.Logica
{
    public class LnEstudiante
    {
        LnConsumoAPI lnConsumoAPI;

        public LnEstudiante()
        {
            lnConsumoAPI = new LnConsumoAPI();
        }

        public async Task<Models.Estudiante.Salida.VerTodosEstudiantes> VerTodosEstudiantes(Models.Estudiante.Entrada.VerTodosEstudiantes pDatos, string token)
        {
            string encabezado = "Estudiante/VerTodosEstudiantes";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Estudiante.Salida.VerTodosEstudiantes>(respuesta);
        }


        public async Task<Models.Estudiante.Salida.VerDetalleEstudiante> VerDetalleEstudiante(Models.Estudiante.Entrada.VerDetalleEstudiante pDatos, string token)
        {
            string encabezado = "Estudiante/VerDetalleEstudiante";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Estudiante.Salida.VerDetalleEstudiante>(respuesta);
        }

        public async Task<Models.Estudiante.Salida.AgregarEstudiante> AgregarEstudiante(Models.Estudiante.Entrada.AgregarEstudiante pDatos, string token)
        {
            string encabezado = "Estudiante/AgregarEstudiante";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Estudiante.Salida.AgregarEstudiante>(respuesta);
        }

        public async Task<Models.Estudiante.Salida.EditarEstudiante> EditarEstudiante(Models.Estudiante.Entrada.EditarEstudiante pDatos, string token)
        {
            string encabezado = "Estudiante/EditarEstudiante";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Estudiante.Salida.EditarEstudiante>(respuesta);
        }

        public async Task<Models.Estudiante.Salida.EliminarEstudiante> EliminarEstudiante(Models.Estudiante.Entrada.EliminarEstudiante pDatos, string token)
        {
            string encabezado = "Estudiante/AgregarEstudiante";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Estudiante.Salida.EliminarEstudiante>(respuesta);
        }
    }
}
