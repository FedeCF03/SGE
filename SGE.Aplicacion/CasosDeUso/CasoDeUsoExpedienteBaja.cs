namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio expedienteRepositorio, ITramiteRepositorio tramiteRepositorio, IServicioAutorizacion servicioAutorizacionProvisorio)
{
    public CasoDeUsoExpedienteBaja Ejecutar(int idUsuario, int idExpediente)
    {
        if (!servicioAutorizacionProvisorio.PoseeElPermiso(idUsuario, Permiso.ExpedienteBaja, Permiso.TramiteBaja))
            throw new AutorizacionExcepcion("No posee el permiso");
        expedienteRepositorio.Baja(idExpediente);
        tramiteRepositorio.BorrarTodosDeIdExpediente(idExpediente);
        return this;
    }

}
