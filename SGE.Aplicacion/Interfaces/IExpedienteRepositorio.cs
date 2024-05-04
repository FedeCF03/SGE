namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
    public void Alta(Expediente expediente);
    public bool Baja(int idExpediente);
    public bool Modificacion(int idUsuario, Expediente expediente);

    public Expediente? BuscarPorId(int idExpediente);


    public List<Expediente>? ListarTodos();

    public List<Expediente>? ListarPorEstado(EstadoExpediente estado);
    public void ActualizarEstado(int idUsuario, int idExpediente, EstadoExpediente estado);
    public int DevolverIdInc();

}