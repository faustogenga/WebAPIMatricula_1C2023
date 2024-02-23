using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace UI.WebMatricula1C2023.Logica
{
    public class LnResidencia
    {
        LnConsumoAPI lnConsumoAPI;

        public LnResidencia()
        {
            lnConsumoAPI = new LnConsumoAPI();
        }

        public async Task<Models.Residencia.Salida.VerTodasResidencias> VerTodasResidencias(Models.Residencia.Entrada.VerTodasResidencias pDatos, string token)
        {
            string encabezado = "Residencia/VerTodasResidencias";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Residencia.Salida.VerTodasResidencias>(respuesta);
        }


        public async Task<Models.Residencia.Salida.VerDetalleResidencia> VerDetalleResidencia(Models.Residencia.Entrada.VerDetalleResidencia pDatos, string token)
        {
            string encabezado = "Residencia/VerDetalleResidencia";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Residencia.Salida.VerDetalleResidencia>(respuesta);
        }

        public async Task<Models.Residencia.Salida.AgregarResidencia> AgregarResidencia(Models.Residencia.Entrada.AgregarResidencia pDatos, string token)
        {
            string encabezado = "Residencia/AgregarResidencia";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Residencia.Salida.AgregarResidencia>(respuesta);
        }

        public async Task<Models.Residencia.Salida.EditarResidencia> EditarResidencia(Models.Residencia.Entrada.EditarResidencia pDatos, string token)
        {
            string encabezado = "Residencia/EditarResidencia";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Residencia.Salida.EditarResidencia>(respuesta);
        }

        public async Task<Models.Residencia.Salida.EliminarResidencia> EliminarResidencia(Models.Residencia.Entrada.EliminarResidencia pDatos, string token)
        {
            string encabezado = "Residencia/EliminarResidencia";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Residencia.Salida.EliminarResidencia>(respuesta);
        }
    }
}
