using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace UI.WebMatricula1C2023.Logica
{
    public class LnProfesor
    {
        LnConsumoAPI lnConsumoAPI;

        public LnProfesor()
        {
            lnConsumoAPI = new LnConsumoAPI();
        }

        public async Task<Models.Profesor.Salida.VerTodosProfesores> VerTodosProfesores(Models.Profesor.Entrada.VerTodosProfesores pDatos, string token)
        {
            string encabezado = "Profesor/VerTodosProfesores";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Profesor.Salida.VerTodosProfesores>(respuesta);
        }


        public async Task<Models.Profesor.Salida.VerDetalleProfesor> VerDetalleProfesor(Models.Profesor.Entrada.VerDetalleProfesor pDatos, string token)
        {
            string encabezado = "Profesor/VerDetalleProfesor";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Profesor.Salida.VerDetalleProfesor>(respuesta);
        }

        public async Task<Models.Profesor.Salida.AgregarProfesor> AgregarProfesor(Models.Profesor.Entrada.AgregarProfesor pDatos, string token)
        {
            string encabezado = "Profesor/AgregarProfesor";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Profesor.Salida.AgregarProfesor>(respuesta);
        }

        public async Task<Models.Profesor.Salida.EditarProfesor> EditarProfesor(Models.Profesor.Entrada.EditarProfesor pDatos, string token)
        {
            string encabezado = "Profesor/EditarProfesor";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Profesor.Salida.EditarProfesor>(respuesta);
        }

        public async Task<Models.Profesor.Salida.EliminarProfesor> EliminarProfesor(Models.Profesor.Entrada.EliminarProfesor pDatos, string token)
        {
            string encabezado = "Profesor/EliminarProfesor";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Profesor.Salida.EliminarProfesor>(respuesta);
        }
    }
}

