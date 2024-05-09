namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio tramiteRepositorio, IExpedienteRepositorio expedienteRepositorio, ServicioAutorizacionProvisorio servicio)
{
    private readonly ITramiteRepositorio _tramiteRepositorio = tramiteRepositorio;
    private readonly ServicioAutorizacionProvisorio _servicio = servicio;

    public void Ejecutar(int usuario, Tramite tramite)
    {
        try
        {
            if (!_servicio.PoseeElPermiso(usuario, Permiso.TramiteModificacion))
                throw new AutorizacionExcepcion("No posee el permiso");

            if (!TramiteValidador.Validar(tramite, usuario, out string mensajeError))
                throw new ValidacionException(mensajeError);

            tramite.FechaUltModificacion = DateTime.Now;
            tramite.UsuarioUltModificacion = usuario;
            if (!_tramiteRepositorio.Modificar(tramite))
                throw new RepositorioException("No se encontró un trámite con ese ID");

            if (_tramiteRepositorio.BuscarUltimo(tramite.ExpedienteId)?.Id == tramite.Id && !ServicioActualizacionEstado.ActualizarEstado(_tramiteRepositorio, expedienteRepositorio, tramite.ExpedienteId, usuario))
                throw new RepositorioException("No se pudo actualizar el estado del expediente");

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }


    }

}

