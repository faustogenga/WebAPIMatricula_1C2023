using Api.Bll.Club.Interfaces;
using Api.Dal.General;
using Api.Dto.Club.Salida;
using Api.Dto.General;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dal.Club
{
    public class AdClub : IAdClub
    {
        private ConexionManager manager;

        public AdClub(IOptions<AppSettings> oConfiguraciones)
        {
            manager = new ConexionManager(oConfiguraciones);
        }

        public Dto.Club.Salida.VerTodosClubes VerTodosClubes()
        {
            IDbConnection oConexion = null;
            Api.Dto.Club.Salida.VerTodosClubes resultado = new Api.Dto.Club.Salida.VerTodosClubes();

            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();

            try
            {
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Todos_Clubes");

                DatosClubes dato;

                while (objDr.Read())
                {
                    dato = new DatosClubes();
                    dato.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    dato.Tipo = objDr["Tipo"].ToString();
                    dato.Nombre = objDr["Nombre"].ToString();
                    dato.Horario = objDr["Horario"].ToString();
                    dato.Ubicacion = objDr["Ubicacion"].ToString();
                    dato.Contacto = objDr["Contacto"].ToString();
                    dato.Encargado = objDr["Encargado"].ToString();
                    resultado.ListaClubes.Add(dato);
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

        public Dto.Club.Salida.VerDetalleClub VerDetalleClub(Dto.Club.Entrada.VerDetalleClub pInformacion)
        {
            IDbConnection oConexion = null;
            Api.Dto.Club.Salida.VerDetalleClub resultado = new Api.Dto.Club.Salida.VerDetalleClub();

            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();

            try
            {
                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Detalle_Club");

                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.Tipo = objDr["Tipo"].ToString();
                    resultado.Nombre = objDr["Nombre"].ToString();
                    resultado.Horario = objDr["Horario"].ToString();
                    resultado.Ubicacion = objDr["Ubicacion"].ToString();
                    resultado.Contacto = objDr["Contacto"].ToString();
                    resultado.Encargado = objDr["Encargado"].ToString();
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

        public Dto.Club.Salida.EditarClub EditarClub(Dto.Club.Entrada.EditarClub pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Club.Salida.EditarClub resultado = new Dto.Club.Salida.EditarClub();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                oComando.Parameters.Add(manager.GetParametro("@Tipo", pInformacion.Tipo));
                oComando.Parameters.Add(manager.GetParametro("@Nombre", pInformacion.Nombre));
                oComando.Parameters.Add(manager.GetParametro("@Horario", pInformacion.Horario));
                oComando.Parameters.Add(manager.GetParametro("@Ubicacion", pInformacion.Ubicacion));
                oComando.Parameters.Add(manager.GetParametro("@Contacto", pInformacion.Contacto));
                oComando.Parameters.Add(manager.GetParametro("@Encargado", pInformacion.Encargado));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Editar_Club");

                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.Tipo = objDr["Tipo"].ToString();
                    resultado.Nombre = objDr["Nombre"].ToString();
                    resultado.Horario = objDr["Horario"].ToString();
                    resultado.Ubicacion = objDr["Ubicacion"].ToString();
                    resultado.Contacto = objDr["Contacto"].ToString();
                    resultado.Encargado = objDr["Encargado"].ToString();
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

        public Dto.Club.Salida.AgregarClub AgregarClub(Dto.Club.Entrada.AgregarClub pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Club.Salida.AgregarClub resultado = new Dto.Club.Salida.AgregarClub();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Tipo", pInformacion.Tipo));
                oComando.Parameters.Add(manager.GetParametro("@Nombre", pInformacion.Nombre));
                oComando.Parameters.Add(manager.GetParametro("@Horario", pInformacion.Horario));
                oComando.Parameters.Add(manager.GetParametro("@Ubicacion", pInformacion.Ubicacion));
                oComando.Parameters.Add(manager.GetParametro("@Contacto", pInformacion.Contacto));
                oComando.Parameters.Add(manager.GetParametro("@Encargado", pInformacion.Encargado));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Agregar_Club");

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

        public Dto.Club.Salida.EliminarClub EliminarClub(Dto.Club.Entrada.EliminarClub pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Club.Salida.EliminarClub resultado = new Dto.Club.Salida.EliminarClub();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Eliminar_Club");
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
