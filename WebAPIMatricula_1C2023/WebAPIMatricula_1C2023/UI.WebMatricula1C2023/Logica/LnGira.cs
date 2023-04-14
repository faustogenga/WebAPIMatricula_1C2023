using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace UI.WebMatricula1C2023.Logica
{
    public class LnGira
    {
        LnConsumoAPI lnConsumoAPI;

        public LnGira()
        {
            lnConsumoAPI = new LnConsumoAPI();
        }

        public async Task<Models.Gira.Salida.VerTodasGiras> VerTodosGiras(Models.Gira.Entrada.VerTodasGiras pDatos, string token)
        {
            string encabezado = "Gira/VerTodasGiras";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Gira.Salida.VerTodasGiras>(respuesta);
        }


        public async Task<Models.Gira.Salida.VerDetalleGira> VerDetalleGira(Models.Gira.Entrada.VerDetalleGira pDatos, string token)
        {
            string encabezado = "Gira/VerDetalleGira";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Gira.Salida.VerDetalleGira>(respuesta);
        }

        public async Task<Models.Gira.Salida.AgregarGira> AgregarGira(Models.Gira.Entrada.AgregarGira pDatos, string token)
        {
            string encabezado = "Gira/AgregarGira";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Gira.Salida.AgregarGira>(respuesta);
        }

        public async Task<Models.Gira.Salida.EditarGira> EditarGira(Models.Gira.Entrada.EditarGira pDatos, string token)
        {
            string encabezado = "Gira/EditarGira";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Gira.Salida.EditarGira>(respuesta);
        }

        public async Task<Models.Gira.Salida.EliminarGira> EliminarGira(Models.Gira.Entrada.EliminarGira pDatos, string token)
        {
            string encabezado = "Gira/EliminarGira";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Gira.Salida.EliminarGira>(respuesta);
        }
    }
}
