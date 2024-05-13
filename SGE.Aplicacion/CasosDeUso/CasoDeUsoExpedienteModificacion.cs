

namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio expedienteRepositorio, IServicioAutorizacion servicioAutorizacionProvisorio)
{
    public CasoDeUsoExpedienteModificacion Ejecutar(int idUsuario, Expediente expediente)
    {
        if (!servicioAutorizacionProvisorio.PoseeElPermiso(idUsuario, Permiso.ExpedienteAlta))
            throw new AutorizacionExcepcion("No posee el permiso");

        if (!ExpedienteValidador.Validar(expediente, idUsuario, out string mensajeError))
            throw new ValidacionException(mensajeError);
        expediente.FechaUltModificacion = DateTime.Now;
        expediente.UsuarioUltModificacion = idUsuario;
        expedienteRepositorio.Modificacion(idUsuario, expediente);//asumimos que no van a cambiar ni el id ni el estado
        return this;

    }

}
