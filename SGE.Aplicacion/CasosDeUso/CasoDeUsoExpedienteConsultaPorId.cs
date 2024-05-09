namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio expedienteRepositorio)
{
    private readonly IExpedienteRepositorio _expedienteRepositorio = expedienteRepositorio;

    public Expediente? Ejecutar(int id)
    {
        try
        {
            Expediente? expediente = _expedienteRepositorio.BuscarPorId(id);
            if (expediente == null)
            {
                throw new RepositorioException("No se encontró el expediente");
            }
            return expediente;
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
            return null;
        }

    }





}
