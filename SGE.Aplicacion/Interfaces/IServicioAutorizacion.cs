namespace SGE.Aplicacion;

public interface IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario, params Permiso[] permiso);
}