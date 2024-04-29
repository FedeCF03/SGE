
namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repositorio, ServicioAutorizacionProvisorio servicioAutorizacionProvisorio, ExpedienteValidador expedienteValidador)
{
    private readonly ExpedienteValidador _expedienteValidador = expedienteValidador;
    private readonly ServicioAutorizacionProvisorio _servicioAutorizacionProvisorio = servicioAutorizacionProvisorio;
    private readonly IExpedienteRepositorio _repositorio = repositorio;
    public void Ejecutar(int idUsuario, Expediente expediente)
    {
        if (_servicioAutorizacionProvisorio.PoseeElPermiso(idUsuario, Permiso.ExpedienteAlta) && _expedienteValidador.Validar(expediente, idUsuario))
        {
            _repositorio.Alta(expediente);
        }
    }


}
