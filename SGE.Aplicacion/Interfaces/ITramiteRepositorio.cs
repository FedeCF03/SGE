namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    void Alta(Tramite tramite);
    int Baja(int idTramite);
    bool BorrarTodosDeIdExpediente(int idExpediente);
    //No se puede modificar el id del tramite, asumimos que el id no se modifica en tramite
    bool Modificar(Tramite tramite);

    Tramite? BuscarPorId(int idTramite);
    List<Tramite>? Listar();

    List<Tramite>? ListarPorEtiqueta(EtiquetaTramite etiqueta);
    Tramite? BuscarUltimo(int idExpediente);

    int DevolverIdInc();


}