namespace SGE.Aplicacion;
public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario, params Permiso[] permiso)
    {
        if (IdUsuario != 1)
            throw new AutorizacionExcepcion("El usuario no está autorizado para realizar la operación pedida.");
        return true;
    }

}
