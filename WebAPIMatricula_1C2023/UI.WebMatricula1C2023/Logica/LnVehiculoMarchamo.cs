using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace UI.WebMatricula1C2023.Logica
{
    public class LnVehiculoMarchamo
    {
        LnConsumoAPI lnConsumoAPI;

        public LnVehiculoMarchamo()
        {
            lnConsumoAPI = new LnConsumoAPI();
        }

        public async Task<Models.VehiculoMarchamo.Salida.VerTodosVehiculoMarchamos> VerTodosVehiculoMarchamos(Models.VehiculoMarchamo.Entrada.VerTodosVehiculoMarchamos pDatos, string token)
        {
            string encabezado = "VehiculoMarchamo/VerTodosVehiculoMarchamos";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.VehiculoMarchamo.Salida.VerTodosVehiculoMarchamos>(respuesta);
        }


        public async Task<Models.VehiculoMarchamo.Salida.VerDetalleVehiculoMarchamo> VerDetalleVehiculoMarchamo(Models.VehiculoMarchamo.Entrada.VerDetalleVehiculoMarchamo pDatos, string token)
        {
            string encabezado = "VehiculoMarchamo/VerDetalleVehiculoMarchamo";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.VehiculoMarchamo.Salida.VerDetalleVehiculoMarchamo>(respuesta);
        }

        public async Task<Models.VehiculoMarchamo.Salida.AgregarVehiculoMarchamo> AgregarVehiculoMarchamo(Models.VehiculoMarchamo.Entrada.AgregarVehiculoMarchamo pDatos, string token)
        {
            string encabezado = "VehiculoMarchamo/AgregarVehiculoMarchamo";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.VehiculoMarchamo.Salida.AgregarVehiculoMarchamo>(respuesta);
        }

        public async Task<Models.VehiculoMarchamo.Salida.EditarVehiculoMarchamo> EditarVehiculoMarchamo(Models.VehiculoMarchamo.Entrada.EditarVehiculoMarchamo pDatos, string token)
        {
            string encabezado = "VehiculoMarchamo/EditarVehiculoMarchamo";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.VehiculoMarchamo.Salida.EditarVehiculoMarchamo>(respuesta);
        }

        public async Task<Models.VehiculoMarchamo.Salida.EliminarVehiculoMarchamo> EliminarVehiculoMarchamo(Models.VehiculoMarchamo.Entrada.EliminarVehiculoMarchamo pDatos, string token)
        {
            string encabezado = "VehiculoMarchamo/EliminarVehiculoMarchamo";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.VehiculoMarchamo.Salida.EliminarVehiculoMarchamo>(respuesta);
        }
    }
}
