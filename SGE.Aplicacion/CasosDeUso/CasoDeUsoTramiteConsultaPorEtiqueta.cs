namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultaPorEtiqueta(ITramiteRepositorio tramiteRepositorio)
{
    private readonly ITramiteRepositorio _tramiteRepositorio = tramiteRepositorio;
    public List<Tramite> Ejecutar(EtiquetaTramite etiqueta)
    {
        return _tramiteRepositorio.ListarPorEtiqueta(etiqueta);
    }//preguntar validacion ? hacemos catch o no 

}

