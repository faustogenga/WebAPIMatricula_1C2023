namespace Api.Bll.Residencia.Interfaces
{
    public interface IAdResidencia
    {
        Api.Dto.Residencia.Salida.VerTodasResidencias VerTodasResidencias();
        Api.Dto.Residencia.Salida.VerDetalleResidencia VerDetalleResidencia(Api.Dto.Residencia.Entrada.VerDetalleResidencia pInformacion);
        Api.Dto.Residencia.Salida.AgregarResidencia AgregarResidencia(Api.Dto.Residencia.Entrada.AgregarResidencia pInformacion);
        Api.Dto.Residencia.Salida.EditarResidencia EditarResidencia(Api.Dto.Residencia.Entrada.EditarResidencia pInformacion);
        Api.Dto.Residencia.Salida.EliminarResidencia EliminarResidencia(Api.Dto.Residencia.Entrada.EliminarResidencia pInformacion);
    }
}
