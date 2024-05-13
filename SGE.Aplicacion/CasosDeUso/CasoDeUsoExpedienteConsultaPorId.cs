namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio expedienteRepositorio, ITramiteRepositorio tramiteRepositorio)
{
    public Expediente Ejecutar(int id)
    {

        Expediente expediente = expedienteRepositorio.BuscarPorId(id);
        expediente.ListaTramites = tramiteRepositorio.ListarTodosDeIdExpediente(id);
        return expediente;
    }
}
