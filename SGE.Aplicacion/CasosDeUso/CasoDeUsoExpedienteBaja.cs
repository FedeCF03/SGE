namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repositorio, ServicioAutorizacionProvisorio servicioAutorizacionProvisorio)
{
    private readonly ServicioAutorizacionProvisorio _servicioAutorizacionProvisorio = servicioAutorizacionProvisorio;
    private readonly IExpedienteRepositorio _repositorio = repositorio;

    public void Ejecutar(int idUsuario, int idExpediente)
    {
        if (_servicioAutorizacionProvisorio.PoseeElPermiso(idUsuario, Permiso.ExpedienteBaja))
        {
            _repositorio.Baja(idExpediente);
        }
    }

}
