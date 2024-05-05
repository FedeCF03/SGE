namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio tramiteRepositorio, IExpedienteRepositorio expedienteRepositorio, ServicioAutorizacionProvisorio servicio)
{
    private readonly ITramiteRepositorio _tramiteRepositorio = tramiteRepositorio;
    private readonly ServicioAutorizacionProvisorio _servicio = servicio;

    public CasoDeUsoTramiteModificacion Ejecutar(int usuario, Tramite tramite)
    {
        if (!_servicio.PoseeElPermiso(usuario, Permiso.TramiteModificacion))
            throw new AutorizacionExcepcion("No posee el permiso");

        if (!TramiteValidador.Validar(tramite, usuario))
            throw new ValidacionException("No se pudo validar el expediente");

        if (!_tramiteRepositorio.Modificar(tramite, out EtiquetaTramite? etiquetaVieja))
            throw new RepositorioException("No se encontró un trámite con ese ID");

        return this;
    }

    //Implementar try y catch acá o en consola principal
    // hacemos throw excepcion dentro del validador o lo hacemos acá?
}

