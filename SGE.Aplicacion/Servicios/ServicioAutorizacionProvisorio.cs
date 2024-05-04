namespace SGE.Aplicacion;
public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario, params Permiso[] permiso)
    {
        if (IdUsuario != 1)
            return false;
        return true;



    }


}
