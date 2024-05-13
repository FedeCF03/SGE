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

    public override string ToString()
    {
        return $"Id: {Id,30}\n\rExpedienteId: {ExpedienteId,30}\n\rEtiqueta: {Etiqueta,30}\n\rContenido: {Contenido,30}\n\rFecha de creación: {FechaCreacion,30}\n\rFecha de última modificación: {FechaUltModificacion,30}\n\rNúmero de último usuario que modificó: {UsuarioUltModificacion,30}";

    }


}