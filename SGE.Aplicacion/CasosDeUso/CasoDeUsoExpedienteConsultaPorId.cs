namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio expedienteRepositorio)
{
    private readonly IExpedienteRepositorio _expedienteRepositorio = expedienteRepositorio;

    public Expediente Ejecutar(int id)
    {

        return _expedienteRepositorio.BuscarPorId(id);
    }





}
