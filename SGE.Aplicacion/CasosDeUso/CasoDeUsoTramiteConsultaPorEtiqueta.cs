namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultaPorEtiqueta(ITramiteRepositorio tramiteRepositorio)
{

    public List<Tramite> Ejecutar(EtiquetaTramite etiqueta)
    {

        List<Tramite>? lista = tramiteRepositorio.ListarPorEtiqueta(etiqueta) ?? throw new RepositorioException("Hubo un error listando los trámites");
        return lista;
    }

}

