namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio tramiteRepositorio, IExpedienteRepositorio expedienteRepositorio, IServicioAutorizacion servicio, IEspecificacionCambioDeEstado especificacionCambioDeEstado)
{
    public CasoDeUsoTramiteModificacion Ejecutar(int usuario, Tramite tramite)
    {
        if (!servicio.PoseeElPermiso(usuario, Permiso.TramiteModificacion))
            throw new AutorizacionExcepcion("No posee el permiso");

        if (!TramiteValidador.Validar(tramite, usuario, out string mensajeError))
            throw new ValidacionException(mensajeError);

        tramite.FechaUltModificacion = DateTime.Now;
        tramite.UsuarioUltModificacion = usuario;

        tramiteRepositorio.Modificar(tramite);
        //Con la primera condición evaluamos si el trámite que modificamos es el último y si no lo es, no se actualiza el estado del expediente.
        Tramite? auxiliar = tramiteRepositorio.BuscarUltimo(tramite.ExpedienteId);
        if (auxiliar?.Id == tramite.Id)
            ServicioActualizacionEstado.ActualizarEstado(tramiteRepositorio, expedienteRepositorio, especificacionCambioDeEstado, tramite.ExpedienteId, usuario);

        Console.WriteLine("Se ha agregado modificado el trámite y el estado del expediente asignado si es que fue necesario");
        return this;
    }

}

