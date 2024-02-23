using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace UI.WebMatricula1C2023.Logica
{
    public class LnCarrera
    {
        LnConsumoAPI lnConsumoAPI;

        public LnCarrera()
        {
            lnConsumoAPI = new LnConsumoAPI();
        }

        public async Task<Models.Carrera.Salida.VerTodasCarreras> VerTodasCarreras(Models.Carrera.Entrada.VerTodasCarreras pDatos, string token)
        {
            string encabezado = "Carrera/VerTodasCarreras";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Carrera.Salida.VerTodasCarreras>(respuesta);
        }


        public async Task<Models.Carrera.Salida.VerDetalleCarrera> VerDetalleCarrera(Models.Carrera.Entrada.VerDetalleCarrera pDatos, string token)
        {
            string encabezado = "Carrera/VerDetalleCarrera";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Carrera.Salida.VerDetalleCarrera>(respuesta);
        }

        public async Task<Models.Carrera.Salida.AgregarCarrera> AgregarCarrera(Models.Carrera.Entrada.AgregarCarrera pDatos, string token)
        {
            string encabezado = "Carrera/AgregarCarrera";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Carrera.Salida.AgregarCarrera>(respuesta);
        }

        public async Task<Models.Carrera.Salida.EditarCarrera> EditarCarrera(Models.Carrera.Entrada.EditarCarrera pDatos, string token)
        {
            string encabezado = "Carrera/EditarCarrera";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Carrera.Salida.EditarCarrera>(respuesta);
        }

        public async Task<Models.Carrera.Salida.EliminarCarrera> EliminarCarrera(Models.Carrera.Entrada.EliminarCarrera pDatos, string token)
        {
            string encabezado = "Carrera/EliminarCarrera";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Carrera.Salida.EliminarCarrera>(respuesta);
        }
    }
}
