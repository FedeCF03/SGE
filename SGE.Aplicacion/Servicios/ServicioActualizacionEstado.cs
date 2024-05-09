using System.Reflection.Metadata.Ecma335;

namespace SGE.Aplicacion;
internal static class ServicioActualizacionEstado
{
    internal static bool ActualizarEstado(ITramiteRepositorio tramiteRepositorio, IExpedienteRepositorio expedienteRepositorio, int ExpedienteId, int idUsuario)
    {
        try
        {
            EstadoExpediente? estado = EspecificacionCambioDeEstado.BuscarEstado(ExpedienteId, tramiteRepositorio);

            // Si estado  es null, no hay que actualizar el expediente.
            // Si el estado no es null, se intenta actualizar y si el expediente se encuentra y se cambia su estado devuelve verdadero, sino falso.
            if (estado != null && !expedienteRepositorio.ActualizarEstado(idUsuario, ExpedienteId, (EstadoExpediente)estado))
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
