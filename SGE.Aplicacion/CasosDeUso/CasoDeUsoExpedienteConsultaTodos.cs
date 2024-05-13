namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaTodos(IExpedienteRepositorio expedienteRepositorio)
{
    public List<Expediente> Ejecutar()
    {

        List<Expediente> lista = expedienteRepositorio.ListarTodos();
        return lista;
    }




}
