namespace SGE.Aplicacion;
internal static class ServicioActualizacionEstado
{
    internal static void ActualizarEstado(ITramiteRepositorio tramiteRepositorio, IExpedienteRepositorio expedienteRepositorio, IEspecificacionCambioDeEstado especificacionCambioDeEstado, int expedienteId, int idUsuario)
    {
        EstadoExpediente? estado = especificacionCambioDeEstado.DevolverEstado(expedienteId, tramiteRepositorio);
        //Si la etiqueta no modificaría el expediente, el metodo de EspecificacionEstado devuelve null y no se actualiza.
        // Si el estado no es null, se intenta actualizar. Si el expediente se encuentra y se cambia su estado.
        if (estado != null)
            expedienteRepositorio.ActualizarEstado(idUsuario, expedienteId, estado);

    }
}