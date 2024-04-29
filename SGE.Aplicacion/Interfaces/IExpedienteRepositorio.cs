namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
    public void Alta(Expediente expediente);
    public void Baja(int idExpediente);
    public void Modificacion(Expediente expediente);

    public Expediente BuscarPorId(int idExpediente);

    public List<Expediente> Listar();
    public List<Expediente> ListarPorId(int idExpediente);
}