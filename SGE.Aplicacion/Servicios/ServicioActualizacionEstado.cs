namespace SGE.Aplicacion;

internal static class ServicioActualizacionEstado
{
    internal static bool ActualizarEstado(ITramiteRepositorio tramiteRepositorio, IExpedienteRepositorio expedienteRepositorio, int ExpedienteId, int idUsuario)
    {
        try
        {
            EstadoExpediente? estado = EspecificacionCambioDeEstado.buscarEstado(ExpedienteId, tramiteRepositorio);
            if (estado != null)
                if (expedienteRepositorio.ActualizarEstado(idUsuario, ExpedienteId, (EstadoExpediente)estado))
                    return true;
                else
                    return false;
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }

    }
}
