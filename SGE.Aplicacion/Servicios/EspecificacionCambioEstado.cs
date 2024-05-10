namespace SGE.Aplicacion;

internal static class EspecificacionCambioDeEstado
{
    internal static EstadoExpediente? BuscarEstado(int ExpedienteId, ITramiteRepositorio tramiteRepositorio)
    {
        Tramite? tramiteAux = tramiteRepositorio.BuscarUltimo(ExpedienteId);
        if (tramiteAux != null)
        {
            switch (tramiteAux.Etiqueta)
            {
                case EtiquetaTramite.Resolucion:
                    return EstadoExpediente.ConResolucion;
                case EtiquetaTramite.PaseAEstudio:
                    return EstadoExpediente.ParaResolver;
                case EtiquetaTramite.PaseAlArchivo:
                    return EstadoExpediente.Finalizado;
                default:
                    return null;
            }
        }
        else
        {
            throw new RepositorioException("No se encontró el trámite con ese numero de expediente");

        }


    }
}


