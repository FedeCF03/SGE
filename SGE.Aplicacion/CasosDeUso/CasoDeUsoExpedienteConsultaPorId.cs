namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio expedienteRepositorio, ITramiteRepositorio tramiteRepositorio)
{
    public Expediente? Ejecutar(int id, out List<Tramite> tramites)
    {

        Expediente? expediente = expedienteRepositorio.BuscarPorId(id) ?? throw new RepositorioException("No se encontró el expediente");
        tramites = tramiteRepositorio.ListarTodosDeIdExpediente(id);
        return expediente;
    }
}
