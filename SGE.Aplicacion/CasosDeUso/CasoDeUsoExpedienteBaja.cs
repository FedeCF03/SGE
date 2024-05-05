namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repositorio, ITramiteRepositorio tramiteRepositorio, ServicioAutorizacionProvisorio servicioAutorizacionProvisorio)
{
    private readonly ServicioAutorizacionProvisorio _servicioAutorizacionProvisorio = servicioAutorizacionProvisorio;
    private readonly IExpedienteRepositorio _expedienteRepositorio = repositorio;
    private readonly ITramiteRepositorio _tramiteRepositorio = tramiteRepositorio;
    public CasoDeUsoExpedienteBaja Ejecutar(int idUsuario, int idExpediente, params Permiso[] permisos)
    {
        if (!_servicioAutorizacionProvisorio.PoseeElPermiso(idUsuario, Permiso.ExpedienteBaja, Permiso.TramiteBaja))
        {
            throw new AutorizacionExcepcion("No posee el permiso");
        }
        if (!_expedienteRepositorio.Baja(idExpediente))
            _tramiteRepositorio.BorrarTodosDeIdExpediente(idExpediente);
        return this;
    }

}
