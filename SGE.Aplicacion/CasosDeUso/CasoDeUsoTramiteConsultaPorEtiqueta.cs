namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultaPorEtiqueta(ITramiteRepositorio tramiteRepositorio)
{
    private readonly ITramiteRepositorio _tramiteRepositorio = tramiteRepositorio;
    public List<Tramite> Ejecutar(EtiquetaTramite etiqueta)
    {
        List<Tramite>? lista = _tramiteRepositorio.ListarPorEtiqueta(etiqueta);
        if (lista == null || lista.Count == 0)
            throw new RepositorioException("No hay expedientes para mostrar");
        return lista;

    }

}

