namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    public void Alta(Tramite tramite);
    public void Baja(int idTramite);

    //No se puede modificar el id del tramite, asumimos que el id no se modifica en tramite
    public void Modificar(Tramite tramite);

    public Tramite BuscarPorId(int idTramite);
    public List<Tramite> Listar();

    public List<Tramite> ListarPorEtiqueta(EtiquetaTramite etiqueta);

}