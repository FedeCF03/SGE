namespace SGE.Aplicacion;

interface IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario, params Permiso[] permiso);
}