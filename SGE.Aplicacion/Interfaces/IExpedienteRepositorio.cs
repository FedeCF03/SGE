namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
    void Alta(Expediente expediente);
    bool Baja(int idExpediente);
    bool Modificacion(int idUsuario, Expediente expediente);

    Expediente? BuscarPorId(int idExpediente);


    List<Expediente>? ListarTodos();

     List<Expediente>? ListarPorEstado(EstadoExpediente estado);
    bool ActualizarEstado(int idUsuario, int idExpediente, EstadoExpediente? estado);

}