namespace SGE.Aplicacion;

internal static class ServicioActualizacionEstado
{
    internal static void ActualizarEstado(ITramiteRepositorio tramiteRepositorio, IExpedienteRepositorio expedienteRepositorio, int ExpedienteId, int idUsuario)
    {
        try
        {
            Console.WriteLine("Actualizando estado del expediente");
            EstadoExpediente? estado = EspecificacionCambioDeEstado.buscarEstado(ExpedienteId, tramiteRepositorio);
            if (estado != null)
                Console.WriteLine(expedienteRepositorio.ActualizarEstado(idUsuario, ExpedienteId, (EstadoExpediente)estado));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
}
