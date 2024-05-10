namespace SGE.Aplicacion;

public class Tramite
{
    public int Id { get; set; }
    public int ExpedienteId { get; set; }
    public EtiquetaTramite Etiqueta { get; set; }
    public string? Contenido { get; set; } = "";
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaUltModificacion { get; set; }
    public int UsuarioUltModificacion { get; set; }


    public Tramite()
    { }

    public Tramite(int expedienteId, EtiquetaTramite etiqueta, string contenido)
    {
        ExpedienteId = expedienteId;
        Etiqueta = etiqueta;
        Contenido = contenido;

    }

    public Tramite(int id, int expedienteId, EtiquetaTramite etiqueta, string contenido) : this(expedienteId, etiqueta, contenido)
    {
        Id = id;
    }

    public override string ToString()
    {
        return $"Id: {Id}\n\rExpedienteId: {ExpedienteId}\n\rEtiqueta: {Etiqueta}\n\rContenido: {Contenido}\n\rFecha de creación: {FechaCreacion}\n\rFecha de última modificación: {FechaUltModificacion}\n\rNúmero de último usuario que modificó: {UsuarioUltModificacion}";

    }


}