

namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repositorio, ServicioAutorizacionProvisorio servicioAutorizacionProvisorio)
{
    private readonly ServicioAutorizacionProvisorio _servicioAutorizacionProvisorio = servicioAutorizacionProvisorio;
    private readonly IExpedienteRepositorio _repositorio = repositorio;

    public CasoDeUsoExpedienteAlta Ejecutar(int idUsuario, Expediente expediente)

    {

        if (!_servicioAutorizacionProvisorio.PoseeElPermiso(idUsuario, Permiso.ExpedienteAlta))
        {
            throw new AutorizacionExcepcion("No posee el permiso");
        }
        if (!ExpedienteValidador.Validar(expediente, idUsuario))
        {
            throw new ValidacionException("No se pudo validar el expediente");
        }
        Console.WriteLine("funciona");
        expediente.FechaCreacion = DateTime.Now;
        expediente.FechaUltModificacion = DateTime.Now;
        expediente.UsuarioUltModificacion = idUsuario;
        _repositorio.Alta(expediente);
        Console.WriteLine("paso repositorio.alta");
        return this;
    }



}
