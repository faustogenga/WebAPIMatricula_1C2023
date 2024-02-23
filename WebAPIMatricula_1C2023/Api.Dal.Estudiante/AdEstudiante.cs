using Api.Bll.Estudiante.Interfaces;
using Api.Dal.General;
using Api.Dto.Estudiante.Salida;
using Api.Dto.General;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dal.Estudiante
{
    public class AdEstudiante : IAdEstudiante
    {
        private ConexionManager manager;

        public AdEstudiante(IOptions<AppSettings> oConfiguraciones)
        {
            manager = new ConexionManager(oConfiguraciones);
        }

        public Dto.Estudiante.Salida.VerTodosEstudiantes VerTodosEstudiantes()
        {
            IDbConnection oConexion = null;
            Api.Dto.Estudiante.Salida.VerTodosEstudiantes resultado = new Api.Dto.Estudiante.Salida.VerTodosEstudiantes();

            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();

            try
            {
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Todos_Estudiantes");

                DatosEstudiante dato;

                while (objDr.Read())
                {
                    dato = new DatosEstudiante();
                    dato.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    dato.Identificacion = objDr["Identificacion"].ToString();
                    dato.NombreCompleto = objDr["NombreCompleto"].ToString();
                    dato.CorreoElectronico = objDr["CorreoElectronico"].ToString();
                    dato.Estado = objDr["Estado"].ToString();

                    resultado.ListaEstudiantes.Add(dato);
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

        public Dto.Estudiante.Salida.VerDetalleEstudiante VerDetalleEstudiante(Dto.Estudiante.Entrada.VerDetalleEstudiante pInformacion)
        {
            IDbConnection oConexion = null;
            Api.Dto.Estudiante.Salida.VerDetalleEstudiante resultado = new Api.Dto.Estudiante.Salida.VerDetalleEstudiante();

            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();

            try
            {
                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Detalle_Estudiante");

                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.Identificacion = objDr["Identificacion"].ToString();
                    resultado.NombreCompleto = objDr["NombreCompleto"].ToString();
                    resultado.CorreoElectronico = objDr["CorreoElectronico"].ToString();
                    resultado.Estado = objDr["Estado"].ToString();
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

        public Dto.Estudiante.Salida.EditarEstudiante EditarEstudiante(Dto.Estudiante.Entrada.EditarEstudiante pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Estudiante.Salida.EditarEstudiante resultado = new Dto.Estudiante.Salida.EditarEstudiante();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                oComando.Parameters.Add(manager.GetParametro("@Identificacion", pInformacion.Identificacion));
                oComando.Parameters.Add(manager.GetParametro("@NombreCompleto", pInformacion.NombreCompleto));
                oComando.Parameters.Add(manager.GetParametro("@CorreoElectronico", pInformacion.CorreoElectronico));
                oComando.Parameters.Add(manager.GetParametro("@Estado", pInformacion.Estado));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Editar_Estudiante");

                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.Identificacion = objDr["Identificacion"].ToString();
                    resultado.NombreCompleto = objDr["NombreCompleto"].ToString();
                    resultado.CorreoElectronico = objDr["CorreoElectronico"].ToString();
                    resultado.Estado = objDr["Estado"].ToString();
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

        public Dto.Estudiante.Salida.AgregarEstudiante AgregarEstudiante(Dto.Estudiante.Entrada.AgregarEstudiante pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Estudiante.Salida.AgregarEstudiante resultado = new Dto.Estudiante.Salida.AgregarEstudiante();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Identificacion", pInformacion.Identificacion));
                oComando.Parameters.Add(manager.GetParametro("@NombreCompleto", pInformacion.NombreCompleto));
                oComando.Parameters.Add(manager.GetParametro("@CorreoElectronico", pInformacion.CorreoElectronico));
                oComando.Parameters.Add(manager.GetParametro("@Estado", pInformacion.Estado));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Agregar_Estudiante");

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

        public Dto.Estudiante.Salida.EliminarEstudiante EliminarEstudiante(Dto.Estudiante.Entrada.EliminarEstudiante pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Estudiante.Salida.EliminarEstudiante resultado = new Dto.Estudiante.Salida.EliminarEstudiante();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Eliminar_Estudiante");
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
