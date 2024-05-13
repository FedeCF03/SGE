
namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio tramiteRepositorio, IExpedienteRepositorio expedienteRepositorio, IServicioAutorizacion servicioAutorizacionProvisorio, IEspecificacionCambioDeEstado especificacionCambioDeEstado)
{
    public CasoDeUsoTramiteAlta Ejecutar(int idUsuario, Tramite tramite)
    {

        if (!servicioAutorizacionProvisorio.PoseeElPermiso(idUsuario, Permiso.TramiteAlta))
            throw new AutorizacionExcepcion("No posee el permiso");

        if (!TramiteValidador.Validar(tramite, idUsuario, out string mensajeError))
            throw new ValidacionException(mensajeError);

        tramite.FechaCreacion = DateTime.Now;
        tramite.FechaUltModificacion = DateTime.Now;
        tramite.UsuarioUltModificacion = idUsuario;
        tramiteRepositorio.Alta(tramite);

        ServicioActualizacionEstado.ActualizarEstado(tramiteRepositorio, expedienteRepositorio, especificacionCambioDeEstado, tramite.ExpedienteId, idUsuario);
        return this;
    }
}





