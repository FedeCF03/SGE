namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repositorio, ServicioAutorizacionProvisorio servicioAutorizacionProvisorio)
{
    private readonly ServicioAutorizacionProvisorio _servicioAutorizacionProvisorio = servicioAutorizacionProvisorio;
    private readonly IExpedienteRepositorio _repositorio = repositorio;

    public void Ejecutar(int idUsuario, int idExpediente, params Permiso[] permisos)
    {
        if (_servicioAutorizacionProvisorio.PoseeElPermiso(idUsuario, permisos))
        {

            //boramos o ponemos como finaliza/inactivo el expediente
            _repositorio.Baja(idExpediente);
        }
    }

}
