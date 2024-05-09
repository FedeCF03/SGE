namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repositorio, ITramiteRepositorio tramiteRepositorio, ServicioAutorizacionProvisorio servicioAutorizacionProvisorio)
{
    private readonly ServicioAutorizacionProvisorio _servicioAutorizacionProvisorio = servicioAutorizacionProvisorio;
    private readonly IExpedienteRepositorio _expedienteRepositorio = repositorio;
    private readonly ITramiteRepositorio _tramiteRepositorio = tramiteRepositorio;
    public void Ejecutar(int idUsuario, int idExpediente)
    {
        try
        {
            if (!_servicioAutorizacionProvisorio.PoseeElPermiso(idUsuario, Permiso.ExpedienteBaja, Permiso.TramiteBaja))
            {
                throw new AutorizacionExcepcion("No posee el permiso");
            }
            if (_expedienteRepositorio.Baja(idExpediente))
            {
                if (!_tramiteRepositorio.BorrarTodosDeIdExpediente(idExpediente))
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
