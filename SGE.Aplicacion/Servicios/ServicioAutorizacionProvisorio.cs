namespace SGE.Aplicacion;
public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario, params Permiso[] permiso)
    {
        if (IdUsuario == 1)
            return true;
        throw new AutorizacionExcepcion("No posee el permiso");
    }


}
