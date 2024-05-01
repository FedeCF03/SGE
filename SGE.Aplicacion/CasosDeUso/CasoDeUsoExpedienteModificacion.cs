namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio expedienteRepositorio, RepositorioException repositorioException, ExpedienteValidador expedienteValidador, ServicioAutorizacionProvisorio servicioAutorizacionProvisorio)
{
    private readonly RepositorioException _repositorioException = repositorioException;
    private readonly IExpedienteRepositorio _expedienteRepositorio = expedienteRepositorio;
    private readonly ExpedienteValidador _expedienteValidador = expedienteValidador;
    private readonly ServicioAutorizacionProvisorio _servicioAutorizacionProvisorio = servicioAutorizacionProvisorio;
    public void Ejecutar(int usuario, Expediente expediente)
    {
        try
        {
            expediente.FechaUltModificacion = DateTime.Now;
            expediente.UsuarioUltModificacion = usu
            if (_servicioAutorizacionProvisorio.PoseeElPermiso(usuario, Permiso.ExpedienteModificacion) && _expedienteValidador.Validar(expediente, usuario))
                if (!_expedienteRepositorio.Modificacion(usuario, expediente))
                {
                    throw new RepositorioException("Error al modificar el expediente");
                }

        }//preguntar como usamos las excepciones 
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }

}
