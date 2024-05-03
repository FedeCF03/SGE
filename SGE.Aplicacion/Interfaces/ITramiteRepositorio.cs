namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    void Alta(Tramite tramite);
    void Baja(int idTramite);

    //No se puede modificar el id del tramite, asumimos que el id no se modifica en tramite
    bool Modificar(Tramite tramite);

    Tramite? BuscarPorId(int idTramite);
    List<Tramite> Listar();

    List<Tramite> ListarPorEtiqueta(EtiquetaTramite etiqueta);
    Tramite? BuscarUltimo(int idExpediente);

    int DevolverIdInc();


}