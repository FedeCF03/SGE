namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio expedienteRepositorio, RepositorioException repositorioException, ExpedienteValidador expedienteValidador, ServicioAutorizacionProvisorio servicioAutorizacionProvisorio)
{
    private readonly RepositorioException _repositorioException = repositorioException;
    private readonly IExpedienteRepositorio _expedienteRepositorio = expedienteRepositorio;
    private readonly ExpedienteValidador _expedienteValidador = expedienteValidador;
    private readonly ServicioAutorizacionProvisorio _servicioAutorizacionProvisorio = servicioAutorizacionProvisorio;
    public void Ejecutar(int idUsuario, Expediente expediente)
    {
        expediente.FechaUltModificacion = DateTime.Now;
        expediente.UsuarioUltModificacion = idUsuario;
        if (_servicioAutorizacionProvisorio.PoseeElPermiso(idUsuario, Permiso.ExpedienteModificacion) && _expedienteValidador.Validar(expediente, idUsuario))
            if (!_expedienteRepositorio.Modificacion(idUsuario, expediente))
            {
                throw new RepositorioException("Error al modificar el expediente");
            }



    }

}
