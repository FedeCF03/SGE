namespace SGE.Aplicacion;

public interface IServicioAutorizacion
{
    bool PoseeElPermiso(int IdUsuario, params Permiso[] permiso);
}