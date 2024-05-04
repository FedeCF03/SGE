namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio expedienteRepositorio)
{
    private readonly IExpedienteRepositorio _expedienteRepositorio = expedienteRepositorio;

    public Expediente Ejecutar(int id)
    {
        Expediente expediente = _expedienteRepositorio.BuscarPorId(id) ?? throw new RepositorioException("No se encontró el expediente");
        return expediente;

    }





}
