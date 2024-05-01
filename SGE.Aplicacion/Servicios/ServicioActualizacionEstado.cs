namespace SGE.Aplicacion;

public class ServicioActualizacionEstado(EspecificacionCambioDeEstado especificacionCambioDeEstado, IExpedienteRepositorio expedienteRepositorio, ITramiteRepositorio tramiteRepositorio)
{
    public void ActualizarEstado(int ExpedienteId, int idUsuario)
    {
        try
        {
            EstadoExpediente estado = especificacionCambioDeEstado.buscarEstado(ExpedienteId, tramiteRepositorio);
            expedienteRepositorio.ActualizarEstado(idUsuario, ExpedienteId, estado);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
}
