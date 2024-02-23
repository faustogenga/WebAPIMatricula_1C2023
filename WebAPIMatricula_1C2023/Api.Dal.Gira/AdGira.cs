using Api.Bll.Gira.Interfaces;
using Api.Dal.General;
using Api.Dto.General;
using Api.Dto.Gira.Salida;
using Microsoft.Extensions.Options;
using System.Data;

namespace Api.Dal.Gira
{
    public class AdGira : IAdGira
    {
        private ConexionManager manager;

        public AdGira(IOptions<AppSettings> oConfiguraciones)
        {
            manager = new ConexionManager(oConfiguraciones);
        }

        public Dto.Gira.Salida.VerTodasGiras VerTodasGiras()
        {
            IDbConnection oConexion = null;
            Api.Dto.Gira.Salida.VerTodasGiras resultado = new Api.Dto.Gira.Salida.VerTodasGiras();

            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();

            try
            {
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Todas_Giras");

                DatosGira dato;

                while (objDr.Read())
                {
                    dato = new DatosGira();
                    dato.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    dato.CodigoGira = objDr["CodigoGira"].ToString();
                    dato.Organizacion = objDr["Organizacion"].ToString();
                    dato.Carreras = objDr["Carreras"].ToString();
                    dato.Fecha = objDr["Fecha"].ToString();
                    dato.HoraSalida = objDr["HoraSalida"].ToString();
                    dato.HoraRegreso = objDr["HoraRegreso"].ToString();
                    dato.Tipo = objDr["Tipo"].ToString();

                    resultado.ListaGiras.Add(dato);
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

        public Dto.Gira.Salida.VerDetalleGira VerDetalleGira(Dto.Gira.Entrada.VerDetalleGira pInformacion)
        {
            IDbConnection oConexion = null;
            Api.Dto.Gira.Salida.VerDetalleGira resultado = new Api.Dto.Gira.Salida.VerDetalleGira();

            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();

            try
            {
                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Detalle_Gira");

                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.CodigoGira = objDr["CodigoGira"].ToString();
                    resultado.Organizacion = objDr["Organizacion"].ToString();
                    resultado.Carreras = objDr["Carreras"].ToString();
                    resultado.Fecha = objDr["Fecha"].ToString();
                    resultado.HoraSalida = objDr["HoraSalida"].ToString();
                    resultado.HoraRegreso = objDr["HoraRegreso"].ToString();
                    resultado.Tipo = objDr["Tipo"].ToString();
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

        public Dto.Gira.Salida.EditarGira EditarGira(Dto.Gira.Entrada.EditarGira pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Gira.Salida.EditarGira resultado = new Dto.Gira.Salida.EditarGira();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                oComando.Parameters.Add(manager.GetParametro("@CodigoGira", pInformacion.CodigoGira));
                oComando.Parameters.Add(manager.GetParametro("@Organizacion", pInformacion.Organizacion));
                oComando.Parameters.Add(manager.GetParametro("@Carreras", pInformacion.Carreras));
                oComando.Parameters.Add(manager.GetParametro("@Fecha", pInformacion.Fecha));
                oComando.Parameters.Add(manager.GetParametro("@HoraSalida", pInformacion.HoraSalida));
                oComando.Parameters.Add(manager.GetParametro("@HoraRegreso", pInformacion.HoraRegreso));
                oComando.Parameters.Add(manager.GetParametro("@Tipo", pInformacion.Tipo));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Editar_Gira");

                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.CodigoGira = objDr["CodigoGira"].ToString();
                    resultado.Organizacion = objDr["Organizacion"].ToString();
                    resultado.Carreras = objDr["Carreras"].ToString();
                    resultado.Fecha = objDr["Fecha"].ToString();
                    resultado.HoraSalida = objDr["HoraSalida"].ToString();
                    resultado.HoraRegreso = objDr["HoraRegreso"].ToString();
                    resultado.Tipo = objDr["Tipo"].ToString();
                }

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

        public Dto.Gira.Salida.AgregarGira AgregarGira(Dto.Gira.Entrada.AgregarGira pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Gira.Salida.AgregarGira resultado = new Dto.Gira.Salida.AgregarGira();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@CodigoGira", pInformacion.CodigoGira));
                oComando.Parameters.Add(manager.GetParametro("@Organizacion", pInformacion.Organizacion));
                oComando.Parameters.Add(manager.GetParametro("@Carreras", pInformacion.Carreras));
                oComando.Parameters.Add(manager.GetParametro("@Fecha", pInformacion.Fecha));
                oComando.Parameters.Add(manager.GetParametro("@HoraSalida", pInformacion.HoraSalida));
                oComando.Parameters.Add(manager.GetParametro("@HoraRegreso", pInformacion.HoraRegreso));
                oComando.Parameters.Add(manager.GetParametro("@Tipo", pInformacion.Tipo));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Agregar_Gira");

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

        public Dto.Gira.Salida.EliminarGira EliminarGira(Dto.Gira.Entrada.EliminarGira pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Gira.Salida.EliminarGira resultado = new Dto.Gira.Salida.EliminarGira();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Eliminar_Gira");
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
