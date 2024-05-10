namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio expedienteRepositorio, ITramiteRepositorio tramiteRepositorio)
{
    public Expediente? Ejecutar(int id, out List<Tramite>? tramites)
    {
        try
        {
            Expediente? expediente = expedienteRepositorio.BuscarPorId(id) ?? throw new RepositorioException("No se encontró el expediente");
            tramites = tramiteRepositorio.ListarTodosDeIdExpediente(id) ?? throw new RepositorioException("Hubo un error listando los tramites del expediente");
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
