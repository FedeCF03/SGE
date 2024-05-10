namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio tramiteRepositorio, IExpedienteRepositorio expedienteRepositorio, ServicioAutorizacionProvisorio servicio)
{
    public void Ejecutar(int usuario, Tramite tramite)
    {
        try
        {
            if (!servicio.PoseeElPermiso(usuario, Permiso.TramiteModificacion))
                throw new AutorizacionExcepcion("No posee el permiso");

            if (!TramiteValidador.Validar(tramite, usuario, out string mensajeError))
                throw new ValidacionException(mensajeError);

            tramite.FechaUltModificacion = DateTime.Now;
            tramite.UsuarioUltModificacion = usuario;
            if (!tramiteRepositorio.Modificar(tramite))
                throw new RepositorioException("No se encontró un trámite con ese ID");

            if (tramiteRepositorio.BuscarUltimo(tramite.ExpedienteId)?.Id == tramite.Id && !ServicioActualizacionEstado.ActualizarEstado(tramiteRepositorio, expedienteRepositorio, tramite.ExpedienteId, usuario))
                throw new RepositorioException("No se pudo actualizar el estado del expediente");

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }


    }

}

