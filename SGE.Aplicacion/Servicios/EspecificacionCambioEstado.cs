namespace SGE.Aplicacion;

internal static class EspecificacionCambioDeEstado
{
    internal static EstadoExpediente buscarEstado(int ExpedienteId, ITramiteRepositorio tramiteRepositorio)
    {
        Tramite? tramiteAux = tramiteRepositorio.BuscarUltimo(ExpedienteId);
        if (tramiteAux != null)
        {
            switch (tramiteAux.Etiqueta)
            {
                case EtiquetaTramite.Resolución:
                    return EstadoExpediente.ConResolución;
                case EtiquetaTramite.PaseAEstudio:
                    return EstadoExpediente.ParaResolver;
                case EtiquetaTramite.PaseAlArchivo:
                    return EstadoExpediente.Finalizado;
            }
        }
        else
        {
            throw new RepositorioException("No se encontró el trámite con ese numero de expediente");

        }
        return EstadoExpediente.ConResolución;


    }
}


