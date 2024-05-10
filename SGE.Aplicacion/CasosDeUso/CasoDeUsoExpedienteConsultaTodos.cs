namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaTodos(IExpedienteRepositorio expedienteRepositorio)
{
    public List<Expediente>? Ejecutar()
    {

        try
        {
            List<Expediente>? lista = expedienteRepositorio.ListarTodos() ?? throw new RepositorioException("Hubo un error listando los expedientes");
            return lista;
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;


    }




}
