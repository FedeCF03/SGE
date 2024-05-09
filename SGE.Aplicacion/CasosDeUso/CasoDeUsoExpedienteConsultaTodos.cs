namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaTodos(IExpedienteRepositorio expedienteRepositorio)
{
    private readonly IExpedienteRepositorio _expedienteRepositorio = expedienteRepositorio;
    public List<Expediente> Ejecutar(int idUsuario)
    {
        List<Expediente>? lista = _expedienteRepositorio.ListarTodos();
        if (lista == null || lista.Count == 0)
            throw new RepositorioException("No hay expedientes para mostrar");
        return lista;

    }




}
