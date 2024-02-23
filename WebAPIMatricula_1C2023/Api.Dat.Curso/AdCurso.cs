
using Api.Bll.Curso.Interfaces;
using Api.Dal.General;
using Api.Dto.Curso.Salida;
using Api.Dto.General;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dal.Curso
{
    public class AdCurso : IAdCurso
    {
        private ConexionManager manager;

        public AdCurso(IOptions<AppSettings> oConfiguraciones)
        {
            manager = new ConexionManager(oConfiguraciones);
        }

        public Dto.Curso.Salida.VerTodosCursos VerTodosCursos()
        {
            IDbConnection oConexion = null;
            Api.Dto.Curso.Salida.VerTodosCursos resultado = new Api.Dto.Curso.Salida.VerTodosCursos();

            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();

            try
            {
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Todos_Cursos");

                DatosCurso dato;

                while (objDr.Read())
                {
                    dato = new DatosCurso();
                    dato.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    dato.Nombre = objDr["Nombre"].ToString();
                    dato.Creditos = Convert.ToInt32(objDr["Creditos"].ToString());
                    dato.Horario = objDr["Horario"].ToString();
                    dato.Cupo = Convert.ToInt32(objDr["Cupo"].ToString());
                    dato.Estado = objDr["Estado"].ToString();

                    resultado.ListaCursos.Add(dato);
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

        public Dto.Curso.Salida.VerDetalleCurso VerDetalleCurso(Dto.Curso.Entrada.VerDetalleCurso pInformacion)
        {
            IDbConnection oConexion = null;
            Api.Dto.Curso.Salida.VerDetalleCurso resultado = new Api.Dto.Curso.Salida.VerDetalleCurso();

            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();

            try
            {
                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Detalle_Curso");

                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.Nombre = objDr["Nombre"].ToString();
                    resultado.Creditos = Convert.ToInt32(objDr["Creditos"].ToString());
                    resultado.Horario = objDr["Horario"].ToString();
                    resultado.Cupo = Convert.ToInt32(objDr["Cupo"].ToString());
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

        public Dto.Curso.Salida.EditarCurso EditarCurso(Dto.Curso.Entrada.EditarCurso pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Curso.Salida.EditarCurso resultado = new Dto.Curso.Salida.EditarCurso();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                oComando.Parameters.Add(manager.GetParametro("@Nombre", pInformacion.Nombre));
                oComando.Parameters.Add(manager.GetParametro("@Creditos", pInformacion.Creditos));
                oComando.Parameters.Add(manager.GetParametro("@Horario", pInformacion.Horario));
                oComando.Parameters.Add(manager.GetParametro("@Cupo", pInformacion.Cupo));
                oComando.Parameters.Add(manager.GetParametro("@Estado", pInformacion.Estado));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Editar_Curso");

                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.Nombre = objDr["Nombre"].ToString();
                    resultado.Creditos = Convert.ToInt32(objDr["Creditos"].ToString());
                    resultado.Horario = objDr["Horario"].ToString();
                    resultado.Cupo = Convert.ToInt32(objDr["Cupo"].ToString());
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

        public Dto.Curso.Salida.AgregarCurso AgregarCurso(Dto.Curso.Entrada.AgregarCurso pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Curso.Salida.AgregarCurso resultado = new Dto.Curso.Salida.AgregarCurso();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Nombre", pInformacion.Nombre));
                oComando.Parameters.Add(manager.GetParametro("@Creditos", pInformacion.Creditos));
                oComando.Parameters.Add(manager.GetParametro("@Horario", pInformacion.Horario));
                oComando.Parameters.Add(manager.GetParametro("@Cupo", pInformacion.Cupo));
                oComando.Parameters.Add(manager.GetParametro("@Estado", pInformacion.Estado));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Agregar_Curso");

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

        public Dto.Curso.Salida.EliminarCurso EliminarCurso(Dto.Curso.Entrada.EliminarCurso pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Curso.Salida.EliminarCurso resultado = new Dto.Curso.Salida.EliminarCurso();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Eliminar_Curso");
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
