namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio expedienteRepositorio, ITramiteRepositorio tramiteRepositorio, ServicioAutorizacionProvisorio servicioAutorizacionProvisorio)
{
    public void Ejecutar(int idUsuario, int idExpediente)
    {
        try
        {
            if (!servicioAutorizacionProvisorio.PoseeElPermiso(idUsuario, Permiso.ExpedienteBaja, Permiso.TramiteBaja))
            {
                throw new AutorizacionExcepcion("No posee el permiso");
            }
            if (expedienteRepositorio.Baja(idExpediente))
            {
                if (!tramiteRepositorio.BorrarTodosDeIdExpediente(idExpediente))
                    throw new RepositorioException("Hubo un error en el borrado de los trámites asociados al expediente");
            }
            else
                throw new RepositorioException("No existe un expediente con ese ID");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

}
