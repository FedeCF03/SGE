namespace SGE.Aplicacion;

interface IServicioAutorizacion
{
    bool PoseeElPermiso(int IdUsuario, params Permiso[] permiso);
}