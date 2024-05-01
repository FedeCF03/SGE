
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
            expediente.FechaCreacion = DateTime.Now;
            expediente.FechaUltModificacion = DateTime.Now;
            expediente.UsuarioUltModificacion = idUsuario;
            _repositorio.Alta(expediente);
        }

    }

    /*
        if (!_servicioAutorizacionProvisorio.PoseeElPermiso(idUsuario, Permiso.ExpedienteAlta)
        {
            throw new throw new AutorizacionExcepcion("No posee el permiso");
        }
        if(!_expedienteValidador.Validar(expediente, idUsuario))
        {
            throw new Exception ValidacionExcepcion("No se pudo validar el expediente");
        }
        _repositorio.Alta(expediente);

    */


}
