namespace SGE.Aplicacion;
public class ServicioAutorizacionProvisorio
{
    public bool PoseeElPermiso(int IdUsuario, Permiso permiso)
    {
        if (IdUsuario == 1)
            return true;
        throw new AutorizacionExcepcion("No posee el permiso");
    }
}
