namespace SGE.Aplicacion;

internal static class ServicioActualizacionEstado
{
    internal static void ActualizarEstado(ITramiteRepositorio tramiteRepositorio, IExpedienteRepositorio expedienteRepositorio, int ExpedienteId, int idUsuario)
    {
        try
        {
            EstadoExpediente estado = EspecificacionCambioDeEstado.buscarEstado(ExpedienteId, tramiteRepositorio);
            expedienteRepositorio.ActualizarEstado(idUsuario, ExpedienteId, estado);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
}
