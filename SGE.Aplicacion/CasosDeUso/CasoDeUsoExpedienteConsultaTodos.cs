namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaTodos(IExpedienteRepositorio expedienteRepositorio)
{
    private readonly IExpedienteRepositorio _expedienteRepositorio = expedienteRepositorio;
    public List<Expediente> Ejecutar()
    {
        return _expedienteRepositorio.ListarTodos();

    }




}
