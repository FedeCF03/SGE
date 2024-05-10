﻿

namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repositorio, ServicioAutorizacionProvisorio servicioAutorizacionProvisorio)
{
    public CasoDeUsoExpedienteAlta Ejecutar(int idUsuario, Expediente expediente)

    {
        try
        {
            if (!servicioAutorizacionProvisorio.PoseeElPermiso(idUsuario, Permiso.ExpedienteAlta))
            {
                throw new AutorizacionExcepcion("No posee el permiso");
            }
            string mensajeError;
            if (!ExpedienteValidador.Validar(expediente, idUsuario, out mensajeError))
            {
                throw new ValidacionException(mensajeError);
            }
            expediente.FechaCreacion = DateTime.Now;
            expediente.FechaUltModificacion = DateTime.Now;
            expediente.UsuarioUltModificacion = idUsuario;
            repositorio.Alta(expediente);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return this;

    }



}
