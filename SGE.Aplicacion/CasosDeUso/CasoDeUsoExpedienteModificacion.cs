

namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio expedienteRepositorio, ServicioAutorizacionProvisorio servicioAutorizacionProvisorio)
{
    private readonly IExpedienteRepositorio _expedienteRepositorio = expedienteRepositorio;

    private readonly ServicioAutorizacionProvisorio _servicioAutorizacionProvisorio = servicioAutorizacionProvisorio;
    public CasoDeUsoExpedienteModificacion Ejecutar(int idUsuario, Expediente expediente)
    {
        if (!_servicioAutorizacionProvisorio.PoseeElPermiso(idUsuario, Permiso.ExpedienteAlta))
        {
            throw new AutorizacionExcepcion("No posee el permiso");
        }
        if (!ExpedienteValidador.Validar(expediente, idUsuario))
        {
            throw new ValidacionException("No se pudo validar el expediente");
        }

        expediente.FechaUltModificacion = DateTime.Now;
        expediente.UsuarioUltModificacion = idUsuario;
        _expedienteRepositorio.Modificacion(idUsuario, expediente);//asumimos que no van a cambiar ni el id ni el estado
        return this;
    }

}
