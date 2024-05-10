

namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio expedienteRepositorio, ServicioAutorizacionProvisorio servicioAutorizacionProvisorio)
{
    private readonly IExpedienteRepositorio _expedienteRepositorio = expedienteRepositorio;

    private readonly ServicioAutorizacionProvisorio _servicioAutorizacionProvisorio = servicioAutorizacionProvisorio;
    public CasoDeUsoExpedienteModificacion Ejecutar(int idUsuario, Expediente expediente)
    {
        try
        {
            if (!_servicioAutorizacionProvisorio.PoseeElPermiso(idUsuario, Permiso.ExpedienteAlta))
            {
                throw new AutorizacionExcepcion("No posee el permiso");
            }
            if (!ExpedienteValidador.Validar(expediente, idUsuario, out string mensajeError))
            {
                throw new ValidacionException(mensajeError);
            }

            expediente.FechaUltModificacion = DateTime.Now;
            expediente.UsuarioUltModificacion = idUsuario;
            if (!_expedienteRepositorio.Modificacion(idUsuario, expediente))//asumimos que no van a cambiar ni el id ni el estado
            {
                throw new RepositorioException("No se encontró un expediente con ese ID o no se pudo modificar");
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return this;

    }

}
