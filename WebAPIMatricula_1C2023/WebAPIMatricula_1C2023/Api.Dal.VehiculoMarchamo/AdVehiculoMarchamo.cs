using Api.Bll.VehiculoMarchamo.Interfaces;
using Api.Dal.General;
using Api.Dto.VehiculoMarchamo.Salida;
using Api.Dto.General;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dal.VehiculoMarchamo
{
    public class AdVehiculoMarchamo : IAdVehiculoMarchamo
    {
        private ConexionManager manager;

        public AdVehiculoMarchamo(IOptions<AppSettings> oConfiguraciones)
        {
            manager = new ConexionManager(oConfiguraciones);
        }

        public Dto.VehiculoMarchamo.Salida.VerTodosVehiculoMarchamos VerTodosVehiculoMarchamos()
        {
            IDbConnection oConexion = null;
            Api.Dto.VehiculoMarchamo.Salida.VerTodosVehiculoMarchamos resultado = new Api.Dto.VehiculoMarchamo.Salida.VerTodosVehiculoMarchamos();

            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();

            try
            {
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Todos_VehiculoMarchamos");

                DatosVehiculoMarchamo dato;

                while (objDr.Read())
                {
                    dato = new DatosVehiculoMarchamo();
                    dato.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    dato.NombreCompleto = objDr["NombreCompleto"].ToString();
                    dato.PlacaVehiculo = objDr["PlacaVehiculo"].ToString();
                    dato.ModeloVehiculo = objDr["ModeloVehiculo"].ToString();
                    dato.ColorVehiculo = objDr["ColorVehiculo"].ToString();

                    resultado.ListaVehiculoMarchamos.Add(dato);
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

        public Dto.VehiculoMarchamo.Salida.VerDetalleVehiculoMarchamo VerDetalleVehiculoMarchamo(Dto.VehiculoMarchamo.Entrada.VerDetalleVehiculoMarchamo pInformacion)
        {
            IDbConnection oConexion = null;
            Api.Dto.VehiculoMarchamo.Salida.VerDetalleVehiculoMarchamo resultado = new Api.Dto.VehiculoMarchamo.Salida.VerDetalleVehiculoMarchamo();

            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();

            try
            {
                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Detalle_VehiculoMarchamo");

                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.NombreCompleto = objDr["NombreCompleto"].ToString();
                    resultado.PlacaVehiculo = objDr["PlacaVehiculo"].ToString();
                    resultado.ModeloVehiculo = objDr["ModeloVehiculo"].ToString();
                    resultado.ColorVehiculo = objDr["ColorVehiculo"].ToString();
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

        public Dto.VehiculoMarchamo.Salida.EditarVehiculoMarchamo EditarVehiculoMarchamo(Dto.VehiculoMarchamo.Entrada.EditarVehiculoMarchamo pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.VehiculoMarchamo.Salida.EditarVehiculoMarchamo resultado = new Dto.VehiculoMarchamo.Salida.EditarVehiculoMarchamo();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                oComando.Parameters.Add(manager.GetParametro("@NombreCompleto", pInformacion.NombreCompleto));
                oComando.Parameters.Add(manager.GetParametro("@PlacaVehiculo", pInformacion.PlacaVehiculo));
                oComando.Parameters.Add(manager.GetParametro("@ModeloVehiculo", pInformacion.ModeloVehiculo));
                oComando.Parameters.Add(manager.GetParametro("@ColorVehiculo", pInformacion.ColorVehiculo));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Editar_VehiculoMarchamo");

                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.NombreCompleto = objDr["NombreCompleto"].ToString();
                    resultado.PlacaVehiculo = objDr["PlacaVehiculo"].ToString();
                    resultado.ModeloVehiculo = objDr["ModeloVehiculo"].ToString();
                    resultado.ColorVehiculo = objDr["ColorVehiculo"].ToString();
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

        public Dto.VehiculoMarchamo.Salida.AgregarVehiculoMarchamo AgregarVehiculoMarchamo(Dto.VehiculoMarchamo.Entrada.AgregarVehiculoMarchamo pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.VehiculoMarchamo.Salida.AgregarVehiculoMarchamo resultado = new Dto.VehiculoMarchamo.Salida.AgregarVehiculoMarchamo();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                
                oComando.Parameters.Add(manager.GetParametro("@NombreCompleto", pInformacion.NombreCompleto));
                oComando.Parameters.Add(manager.GetParametro("@PlacaVehiculo", pInformacion.PlacaVehiculo));
                oComando.Parameters.Add(manager.GetParametro("@ModeloVehiculo", pInformacion.ModeloVehiculo));
                oComando.Parameters.Add(manager.GetParametro("@ColorVehiculo", pInformacion.ColorVehiculo));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Agregar_VehiculoMarchamo");

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

        public Dto.VehiculoMarchamo.Salida.EliminarVehiculoMarchamo EliminarVehiculoMarchamo(Dto.VehiculoMarchamo.Entrada.EliminarVehiculoMarchamo pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.VehiculoMarchamo.Salida.EliminarVehiculoMarchamo resultado = new Dto.VehiculoMarchamo.Salida.EliminarVehiculoMarchamo();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Eliminar_VehiculoMarchamo");
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
