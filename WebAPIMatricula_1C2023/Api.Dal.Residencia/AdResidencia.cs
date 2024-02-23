using Api.Dal.General;
using Api.Dto.Residencia.Salida;
using Api.Dto.General;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Bll.Residencia.Interfaces;

namespace Api.Dal.Residencia
{

    public class AdResidencia : IAdResidencia
    {
        private ConexionManager manager;

        public AdResidencia(IOptions<AppSettings> oConfiguraciones)
        {
            manager = new ConexionManager(oConfiguraciones);
        }

        public Dto.Residencia.Salida.VerTodasResidencias VerTodasResidencias()
        {
            IDbConnection oConexion = null;
            Api.Dto.Residencia.Salida.VerTodasResidencias resultado = new Api.Dto.Residencia.Salida.VerTodasResidencias();

            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();

            try
            {
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Todas_Residencias");

                DatosResidencia dato;

                while (objDr.Read())
                {
                    dato = new DatosResidencia();
                    dato.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    dato.Cedula = Convert.ToInt32(objDr["Cedula"].ToString());
                    dato.Pais = objDr["Pais"].ToString();
                    dato.Provincia = objDr["Provincia"].ToString();
                    dato.Canton = objDr["Canton"].ToString();
                    dato.Distrito = objDr["Distrito"].ToString();
                    dato.DirExacta = objDr["DirExacta"].ToString();

                    resultado.ListaResidencias.Add(dato);
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

        public Dto.Residencia.Salida.VerDetalleResidencia VerDetalleResidencia(Dto.Residencia.Entrada.VerDetalleResidencia pInformacion)
        {
            IDbConnection oConexion = null;
            Api.Dto.Residencia.Salida.VerDetalleResidencia resultado = new Api.Dto.Residencia.Salida.VerDetalleResidencia();

            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();

            try
            {
                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Detalle_Residencia");

                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.Cedula = Convert.ToInt32(objDr["Cedula"].ToString());
                    resultado.Pais = objDr["Pais"].ToString();
                    resultado.Provincia = objDr["Provincia"].ToString();
                    resultado.Canton = objDr["Canton"].ToString();
                    resultado.Distrito = objDr["Distrito"].ToString();
                    resultado.DirExacta = objDr["DirExacta"].ToString();
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

        public Dto.Residencia.Salida.EditarResidencia EditarResidencia(Dto.Residencia.Entrada.EditarResidencia pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Residencia.Salida.EditarResidencia resultado = new Dto.Residencia.Salida.EditarResidencia();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                oComando.Parameters.Add(manager.GetParametro("@Cedula", pInformacion.Cedula));
                oComando.Parameters.Add(manager.GetParametro("@Pais", pInformacion.Pais));
                oComando.Parameters.Add(manager.GetParametro("@Provincia", pInformacion.Provincia));
                oComando.Parameters.Add(manager.GetParametro("@Canton", pInformacion.Canton));
                oComando.Parameters.Add(manager.GetParametro("@Distrito", pInformacion.Distrito));
                oComando.Parameters.Add(manager.GetParametro("@DirExacta", pInformacion.DirExacta));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Editar_Residencia");

                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.Cedula = Convert.ToInt32(objDr["Cedula"].ToString());
                    resultado.Pais = objDr["Pais"].ToString();
                    resultado.Provincia = objDr["Provincia"].ToString();
                    resultado.Canton = objDr["Canton"].ToString();
                    resultado.Distrito = objDr["Distrito"].ToString();
                    resultado.DirExacta = objDr["DirExacta"].ToString();
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

        public Dto.Residencia.Salida.AgregarResidencia AgregarResidencia(Dto.Residencia.Entrada.AgregarResidencia pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Residencia.Salida.AgregarResidencia resultado = new Dto.Residencia.Salida.AgregarResidencia();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Cedula", pInformacion.Cedula));
                oComando.Parameters.Add(manager.GetParametro("@Pais", pInformacion.Pais));
                oComando.Parameters.Add(manager.GetParametro("@Provincia", pInformacion.Provincia));
                oComando.Parameters.Add(manager.GetParametro("@Canton", pInformacion.Canton));
                oComando.Parameters.Add(manager.GetParametro("@Distrito", pInformacion.Distrito));
                oComando.Parameters.Add(manager.GetParametro("@DirExacta", pInformacion.DirExacta));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Agregar_Residencia");

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

        public Dto.Residencia.Salida.EliminarResidencia EliminarResidencia(Dto.Residencia.Entrada.EliminarResidencia pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Residencia.Salida.EliminarResidencia resultado = new Dto.Residencia.Salida.EliminarResidencia();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Eliminar_Residencia");
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
