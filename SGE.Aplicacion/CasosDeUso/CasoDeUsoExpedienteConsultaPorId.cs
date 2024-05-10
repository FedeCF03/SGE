namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio expedienteRepositorio, ITramiteRepositorio tramiteRepositorio)
{
    private readonly IExpedienteRepositorio _expedienteRepositorio = expedienteRepositorio;
    private readonly ITramiteRepositorio _tramiteRepositorio = tramiteRepositorio;
    public Expediente? Ejecutar(int id, out List<Tramite>? tramites)
    {
        try
        {
            Expediente? expediente = _expedienteRepositorio.BuscarPorId(id) ?? throw new RepositorioException("No se encontró el expediente");
            tramites = _tramiteRepositorio.ListarTodosDeIdExpediente(id) ?? throw new RepositorioException("Hubo un error listando los tramites del expediente");
            return expediente;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            tramites = null;
            return null;
        }

    }





}
