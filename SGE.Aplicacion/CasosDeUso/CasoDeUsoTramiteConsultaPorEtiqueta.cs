namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultaPorEtiqueta(ITramiteRepositorio tramiteRepositorio)
{
    private readonly ITramiteRepositorio _tramiteRepositorio = tramiteRepositorio;
    public List<Tramite> Ejecutar(EtiquetaTramite etiqueta)
    {
        try
        {
            Console.WriteLine(etiqueta);
            List<Tramite>? lista = _tramiteRepositorio.ListarPorEtiqueta(etiqueta);
            if (lista == null)
                throw new RepositorioException("Hubo un error listando los trámites");
            return lista;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return [];
        }



    }

}

