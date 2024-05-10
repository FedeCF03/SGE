
namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio tramiteRepositorio, IExpedienteRepositorio expedienteRepositorio, ServicioAutorizacionProvisorio servicioAutorizacionProvisorio)
{
    public CasoDeUsoTramiteAlta Ejecutar(int idUsuario, Tramite tramite)
    {
        try
        {
            if (!servicioAutorizacionProvisorio.PoseeElPermiso(idUsuario, Permiso.TramiteAlta))
            {
                throw new AutorizacionExcepcion("No posee el permiso");
            }
            if (!TramiteValidador.Validar(tramite, idUsuario, out string mensajeError))
            {
                throw new ValidacionException(mensajeError);
            }

            tramite.FechaCreacion = DateTime.Now;
            tramite.FechaUltModificacion = DateTime.Now;
            tramite.UsuarioUltModificacion = idUsuario;

            tramiteRepositorio.Alta(tramite);
            Console.WriteLine("añadió tramite");

            if (!ServicioActualizacionEstado.ActualizarEstado(tramiteRepositorio, expedienteRepositorio, tramite.ExpedienteId, idUsuario))
            {
                throw new RepositorioException("No hay un expediente asociado al trámite.");
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return this;

    }

    //Cambio de estado
    /*
    Además, resultaría beneficioso desacoplar el servicio de la especificación que define qué cambio de estado
    debe llevarse a cabo en función de la etiqueta del último trámite. Esta especificación podría ser
    suministrada al servicio mediante la técnica de inyección de dependencias. 

    Preguntar si estaría bien llamar a ServicioActualizacionDeEstado que llame a EspecificacionCambioEstado que devuelva el estado nuevo del expediente, 
    para eso llama a ITramiteRepositorio, que busca el ultimo trámite de dicho expediente 
    ???????
    */
}





