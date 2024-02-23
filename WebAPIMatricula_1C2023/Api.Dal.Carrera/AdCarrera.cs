using Api.Bll.Carrera.Interfaces;
using Api.Dal.General;
using Api.Dto.Carrera.Salida;
using Api.Dto.General;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Dal.Carrera
{
    public class AdCarrera : IAdCarrera
    {
        private ConexionManager manager;

        public AdCarrera(IOptions<AppSettings> oConfiguraciones)
        {
            manager = new ConexionManager(oConfiguraciones);
        }

        public Dto.Carrera.Salida.VerTodasCarreras VerTodasCarreras()
        {
            IDbConnection oConexion = null;
            Api.Dto.Carrera.Salida.VerTodasCarreras resultado = new Api.Dto.Carrera.Salida.VerTodasCarreras();

            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();

            try
            {
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Todas_Carreras");

                DatosCarrera dato;

                while (objDr.Read())
                {
                    dato = new DatosCarrera();
                    dato.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    dato.Carrera = objDr["Carrera"].ToString();
                    dato.Sede = objDr["Sede"].ToString();
                    dato.Cuatrimestres = Convert.ToInt32(objDr["Cuatrimestres"].ToString());
                    dato.Idioma = objDr["Idioma"].ToString();
                    dato.MateriasMatriculadas = Convert.ToInt32(objDr["MateriasMatriculadas"].ToString());



                    resultado.ListaCarreras.Add(dato);
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

        public Dto.Carrera.Salida.VerDetalleCarrera VerDetalleCarrera(Dto.Carrera.Entrada.VerDetalleCarrera pInformacion)
        {
            IDbConnection oConexion = null;
            Api.Dto.Carrera.Salida.VerDetalleCarrera resultado = new Api.Dto.Carrera.Salida.VerDetalleCarrera();

            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();

            try
            {
                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Detalle_Carrera");

                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.Carrera = objDr["Carrera"].ToString();
                    resultado.Sede = objDr["Sede"].ToString();
                    resultado.Cuatrimestres = Convert.ToInt32(objDr["Cuatrimestres"].ToString());
                    resultado.Idioma = objDr["Idioma"].ToString();
                    resultado.MateriasMatriculadas = Convert.ToInt32(objDr["MateriasMatriculadas"].ToString());
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

        public Dto.Carrera.Salida.EditarCarrera EditarCarrera(Dto.Carrera.Entrada.EditarCarrera pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Carrera.Salida.EditarCarrera resultado = new Dto.Carrera.Salida.EditarCarrera();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                oComando.Parameters.Add(manager.GetParametro("@Carrera", pInformacion.Carrera));
                oComando.Parameters.Add(manager.GetParametro("@Sede", pInformacion.Sede));
                oComando.Parameters.Add(manager.GetParametro("@Cuatrimestres", pInformacion.Cuatrimestres));
                oComando.Parameters.Add(manager.GetParametro("@Idioma", pInformacion.Idioma));
                oComando.Parameters.Add(manager.GetParametro("@MateriasMatriculadas", pInformacion.MateriasMatriculadas));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Editar_Carrera");

                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.Carrera = objDr["Carrera"].ToString();
                    resultado.Sede = objDr["Sede"].ToString();
                    resultado.Cuatrimestres = Convert.ToInt32(objDr["Cuatrimestres"].ToString());
                    resultado.Idioma = objDr["Idioma"].ToString();
                    resultado.MateriasMatriculadas = Convert.ToInt32(objDr["MateriasMatriculadas"].ToString());
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

        public Dto.Carrera.Salida.AgregarCarrera AgregarCarrera(Dto.Carrera.Entrada.AgregarCarrera pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Carrera.Salida.AgregarCarrera resultado = new Dto.Carrera.Salida.AgregarCarrera();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                
                oComando.Parameters.Add(manager.GetParametro("@Carrera", pInformacion.Carrera));
                oComando.Parameters.Add(manager.GetParametro("@Sede", pInformacion.Sede));
                oComando.Parameters.Add(manager.GetParametro("@Cuatrimestres", pInformacion.Cuatrimestres));
                oComando.Parameters.Add(manager.GetParametro("@Idioma", pInformacion.Idioma));
                oComando.Parameters.Add(manager.GetParametro("@MateriasMatriculadas", pInformacion.MateriasMatriculadas));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Agregar_Carrera");

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

        public Dto.Carrera.Salida.EliminarCarrera EliminarCarrera(Dto.Carrera.Entrada.EliminarCarrera pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Carrera.Salida.EliminarCarrera resultado = new Dto.Carrera.Salida.EliminarCarrera();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Eliminar_Carrera");
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
