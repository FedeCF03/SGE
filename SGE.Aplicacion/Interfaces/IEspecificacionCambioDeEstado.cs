using SGE.Aplicacion;
namespace SGE.Aplicacion;
public interface IEspecificacionCambioDeEstado
{
    public EstadoExpediente? DevolverEstado(int ExpedienteId, ITramiteRepositorio tramiteRepositorio);
}
