namespace SGE.Aplicacion;
public class EspecificacionCambioDeEstado()
{
    public EstadoExpediente buscarEstado(int ExpedienteId, ITramiteRepositorio tramiteRepositorio)
    {
        Tramite? tramiteAux = tramiteRepositorio.buscarUltimo(ExpedienteId);
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
            throw new RepositorioException("No se encontró el trámite");

        }
        return EstadoExpediente.ConResolución;


    }
}


