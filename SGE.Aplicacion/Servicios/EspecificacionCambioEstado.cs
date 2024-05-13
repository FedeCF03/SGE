namespace SGE.Aplicacion;

public class EspecificacionCambioDeEstado : IEspecificacionCambioDeEstado
{
    public EstadoExpediente? DevolverEstado(int ExpedienteId, ITramiteRepositorio tramiteRepositorio)
    {
        Tramite? tramiteAux = tramiteRepositorio.BuscarUltimo(ExpedienteId);
        //Si el trámite es null, significa que el expediente no tiene trámites por lo que se lleva el estado del expediente
        //al original
        if (tramiteAux == null)
            return EstadoExpediente.RecienIniciado;

        return tramiteAux.Etiqueta switch
        {
            EtiquetaTramite.Resolucion => EstadoExpediente.ConResolucion,
            EtiquetaTramite.PaseAEstudio => EstadoExpediente.ParaResolver,
            EtiquetaTramite.PaseAlArchivo => EstadoExpediente.Finalizado,
            _ => null,
        };
    }
}



