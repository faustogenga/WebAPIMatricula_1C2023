using Api.Bll.Profesor.Interfaces;
using Api.Dal.General;
using Api.Dto.Profesor.Salida;
using Api.Dto.General;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dal.Profesor
{
    public class AdProfesor : IAdProfesor
    {
        private ConexionManager manager;

        public AdProfesor(IOptions<AppSettings> oConfiguraciones)
        {
            manager = new ConexionManager(oConfiguraciones);
        }

        public Dto.Profesor.Salida.VerTodosProfesores VerTodosProfesores()
        {
            IDbConnection oConexion = null;
            Api.Dto.Profesor.Salida.VerTodosProfesores resultado = new Api.Dto.Profesor.Salida.VerTodosProfesores();

            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();

            try
            {
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Todos_Profesores");

                DatosProfesor dato;

                while (objDr.Read())
                {
                    dato = new DatosProfesor();
                    dato.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    dato.Identificacion = objDr["Identificacion"].ToString();
                    dato.NombreProfesor = objDr["NombreProfesor"].ToString();
                    dato.CorreoElectronico = objDr["CorreoElectronico"].ToString();
                    dato.CarreraProfesional = objDr["CarreraProfesional"].ToString();

                    resultado.ListaProfesores.Add(dato);
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

        public Dto.Profesor.Salida.VerDetalleProfesor VerDetalleProfesor(Dto.Profesor.Entrada.VerDetalleProfesor pInformacion)
        {
            IDbConnection oConexion = null;
            Api.Dto.Profesor.Salida.VerDetalleProfesor resultado = new Api.Dto.Profesor.Salida.VerDetalleProfesor();

            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();

            try
            {
                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Detalle_Profesor");

                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.Identificacion = objDr["Identificacion"].ToString();
                    resultado.NombreProfesor = objDr["NombreProfesor"].ToString();
                    resultado.CorreoElectronico = objDr["CorreoElectronico"].ToString();
                    resultado.CarreraProfesional = objDr["CarreraProfesional"].ToString();
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

        public Dto.Profesor.Salida.EditarProfesor EditarProfesor(Dto.Profesor.Entrada.EditarProfesor pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Profesor.Salida.EditarProfesor resultado = new Dto.Profesor.Salida.EditarProfesor();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                oComando.Parameters.Add(manager.GetParametro("@Identificacion", pInformacion.Identificacion));
                oComando.Parameters.Add(manager.GetParametro("@NombreProfesor", pInformacion.NombreProfesor));
                oComando.Parameters.Add(manager.GetParametro("@CorreoElectronico", pInformacion.CorreoElectronico));
                oComando.Parameters.Add(manager.GetParametro("@CarreraProfesional", pInformacion.CarreraProfesional));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Editar_Profesor");

                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.Identificacion = objDr["Identificacion"].ToString();
                    resultado.NombreProfesor = objDr["NombreProfesor"].ToString();
                    resultado.CorreoElectronico = objDr["CorreoElectronico"].ToString();
                    resultado.CarreraProfesional = objDr["CarreraProfesional"].ToString();
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

        public Dto.Profesor.Salida.AgregarProfesor AgregarProfesor(Dto.Profesor.Entrada.AgregarProfesor pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Profesor.Salida.AgregarProfesor resultado = new Dto.Profesor.Salida.AgregarProfesor();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Identificacion", pInformacion.Identificacion));
                oComando.Parameters.Add(manager.GetParametro("@NombreProfesor", pInformacion.NombreProfesor));
                oComando.Parameters.Add(manager.GetParametro("@CorreoElectronico", pInformacion.CorreoElectronico));
                oComando.Parameters.Add(manager.GetParametro("@CarreraProfesional", pInformacion.CarreraProfesional));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Agregar_Profesor");

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

        public Dto.Profesor.Salida.EliminarProfesor EliminarProfesor(Dto.Profesor.Entrada.EliminarProfesor pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Profesor.Salida.EliminarProfesor resultado = new Dto.Profesor.Salida.EliminarProfesor();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Eliminar_Profesor");
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
