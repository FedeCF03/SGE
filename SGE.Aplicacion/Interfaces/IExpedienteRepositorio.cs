namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
    void Alta(Expediente expediente);
    void Baja(int idExpediente);
    void Modificacion(int idUsuario, Expediente expediente);
    Expediente BuscarPorId(int idExpediente);
    List<Expediente> ListarTodos();
    List<Expediente> ListarPorEstado(EstadoExpediente estado);
    void ActualizarEstado(int idUsuario, int idExpediente, EstadoExpediente? estado);

}