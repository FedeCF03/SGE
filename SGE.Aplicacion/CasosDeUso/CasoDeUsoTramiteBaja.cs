namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio tramiteRepositorio, IExpedienteRepositorio expedienteRepositorio, ServicioAutorizacionProvisorio servicioAutorizacionProvisorio)
{
    private readonly ITramiteRepositorio _tramiteRepositorio = tramiteRepositorio;
    IExpedienteRepositorio _expedienteRepositorio = expedienteRepositorio;

    public CasoDeUsoTramiteBaja Ejecutar(int usuario, int idTramite)
    {
        if (!servicioAutorizacionProvisorio.PoseeElPermiso(usuario, Permiso.TramiteBaja))
        {
            throw new AutorizacionExcepcion("No posee el permiso");
        }
        int idExpediente;
        if ((idExpediente = _tramiteRepositorio.Baja(idTramite)) == -1)
        {
            throw new RepositorioException("El trámite no tiene asignado ningún expediente");
        }
        ServicioActualizacionEstado.ActualizarEstado(_tramiteRepositorio, _expedienteRepositorio, idExpediente, usuario);

        return this;
    }
}



