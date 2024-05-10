namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaTodos(IExpedienteRepositorio expedienteRepositorio)
{
    private readonly IExpedienteRepositorio _expedienteRepositorio = expedienteRepositorio;
    public List<Expediente>? Ejecutar(int idUsuario)
    {

        try
        {
            List<Expediente>? lista = _expedienteRepositorio.ListarTodos() ?? throw new RepositorioException("Hubo un error listando los expedientes");
            return lista;
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return null;


    }




}
