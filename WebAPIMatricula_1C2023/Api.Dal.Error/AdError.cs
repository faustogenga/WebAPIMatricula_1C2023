using Api.Bll.Error.Interfaces;
using Api.Dal.General;
using Api.Dto.Error.Salida;
using Api.Dto.General;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dal.Error
{
    public class AdError : IAdError
    {
        private ConexionManager manager;
        public AdError(IOptions<AppSettings> oconfiguraciones)
        {
            manager = new ConexionManager(oconfiguraciones);
        }

        public Dto.Error.Salida.VerTodosErrores VerTodosErrores()
        {
            IDbConnection oConexion = null;
            Api.Dto.Error.Salida.VerTodosErrores resultado = new Api.Dto.Error.Salida.VerTodosErrores();

            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();

            try
            {
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Todos_Errores");

                DatosError dato;

                while (objDr.Read())
                {
                    dato = new DatosError();
                    dato.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    dato.CodigoUsuario = Convert.ToInt32(objDr["CodigoUsuario"].ToString());
                    dato.FechaHora = Convert.ToDateTime(objDr["FechaHora"].ToString());
                    dato.Modulo = objDr["Modulo"].ToString();
                    dato.Clase = objDr["Clase"].ToString();
                    dato.Metodo = objDr["Metodo"].ToString();
                    dato.Fuente = objDr["Fuente"].ToString();
                    dato.Numero = Convert.ToInt32(objDr["Numero"].ToString());
                    dato.Excepcion = objDr["Excepcion"].ToString();

                    resultado.ListaErrores.Add(dato);
                }
            }
            catch (Exception)
            {
                manager.CerrarConexion(oConexion);
            }
            finally
            {
                manager.CerrarConexion(oConexion);
            }

            return resultado;
        }
        public Dto.Error.Salida.AgregarError AgregarError(Dto.Error.Entrada.AgregarError pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Error.Salida.AgregarError resultado = new Dto.Error.Salida.AgregarError();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@CodigoUsuario", pInformacion.CodigoUsuario));
                oComando.Parameters.Add(manager.GetParametro("@FechaHora", pInformacion.FechaHora));
                oComando.Parameters.Add(manager.GetParametro("@Modulo", pInformacion.Modulo));
                oComando.Parameters.Add(manager.GetParametro("@Clase", pInformacion.Clase));
                oComando.Parameters.Add(manager.GetParametro("@Metodo", pInformacion.Metodo));
                oComando.Parameters.Add(manager.GetParametro("@Fuente", pInformacion.Fuente));
                oComando.Parameters.Add(manager.GetParametro("@Numero", pInformacion.Numero));
                oComando.Parameters.Add(manager.GetParametro("@Excepcion", pInformacion.Excepcion));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Agregar_Error");

                if (objDr.Read())
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());

            }
            catch (Exception ex)
            {
                resultado.DetalleRespuesta = ex.Message;
                manager.CerrarConexion(oConexion);
            }
            finally
            {
                manager.CerrarConexion(oConexion);
            }

            return resultado;
        }
    }
}
