namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    void Alta(Tramite tramite);
    //El metodo devuelve el ID del expediente al que el trámite está asignado, o -1 si no existe dicho trámite
    void Baja(int idTramite, out int idExpediente);
    void Modificar(Tramite tramite);
    //No se puede modificar el id del tramite, asumimos que el id no se modifica en tramite
    Tramite BuscarPorId(int idTramite);
    List<Tramite> ListarTodos();
    List<Tramite> ListarPorEtiqueta(EtiquetaTramite etiqueta);
    List<Tramite> ListarTodosDeIdExpediente(int expedienteId);
    void BorrarTodosDeIdExpediente(int idExpediente);
    Tramite? BuscarUltimo(int idExpediente);



}