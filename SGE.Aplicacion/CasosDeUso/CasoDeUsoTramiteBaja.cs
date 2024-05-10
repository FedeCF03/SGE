namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio tramiteRepositorio, IExpedienteRepositorio expedienteRepositorio, ServicioAutorizacionProvisorio servicioAutorizacionProvisorio)
{

    public CasoDeUsoTramiteBaja Ejecutar(int usuario, int idTramite)
    {
        try
        {
            if (!servicioAutorizacionProvisorio.PoseeElPermiso(usuario, Permiso.TramiteBaja))
            {
                throw new AutorizacionExcepcion("No posee el permiso");
            }
            int idExpediente;
            if ((idExpediente = tramiteRepositorio.Baja(idTramite)) == -1)
            {
                throw new RepositorioException("El trámite no tiene asignado ningún expediente");
            }
            if (!ServicioActualizacionEstado.ActualizarEstado(tramiteRepositorio, expedienteRepositorio, idExpediente, usuario))
                throw new RepositorioException("No hay un expediente asociado al trámite");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return this;

    }
}



