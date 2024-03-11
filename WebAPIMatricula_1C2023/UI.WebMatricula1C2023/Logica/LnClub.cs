using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace UI.WebMatricula1C2023.Logica
{
    public class LnClub
    {
        LnConsumoAPI lnConsumoAPI;

        public LnClub()
        {
            lnConsumoAPI = new LnConsumoAPI();
        }

        public async Task<Models.Club.Salida.VerTodosClubes> VerTodosClubes(Models.Club.Entrada.VerTodosClubes pDatos, string token)
        {
            string encabezado = "Club/VerTodosClubes";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Club.Salida.VerTodosClubes>(respuesta);
        }


        public async Task<Models.Club.Salida.VerDetalleClub> VerDetalleClub(Models.Club.Entrada.VerDetalleClub pDatos, string token)
        {
            string encabezado = "Club/VerDetalleClub";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Club.Salida.VerDetalleClub>(respuesta);
        }

        public async Task<Models.Club.Salida.AgregarClub> AgregarClub(Models.Club.Entrada.AgregarClub pDatos, string token)
        {
            string encabezado = "Club/AgregarClub";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Club.Salida.AgregarClub>(respuesta);
        }

        public async Task<Models.Club.Salida.EditarClub> EditarClub(Models.Club.Entrada.EditarClub pDatos, string token)
        {
            string encabezado = "Club/EditarClub";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Club.Salida.EditarClub>(respuesta);
        }

        public async Task<Models.Club.Salida.EliminarClub> EliminarClub(Models.Club.Entrada.EliminarClub pDatos, string token)
        {
            string encabezado = "Club/EliminarClub";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Club.Salida.EliminarClub>(respuesta);
        }
    }
}
