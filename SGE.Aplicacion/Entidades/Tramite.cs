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
        return $"{"ID: ",-40}{Id}\n\r{"ExpedienteId: ",-40}{ExpedienteId}\n\r{"Etiqueta: ",-40}{Etiqueta}\n\r{"Contenido: ",-40}{Contenido}\n\r{"Fecha de creacion: ",-40}{FechaCreacion:dd/MM/yyyy H:mm:ss}\n\r{"Fecha de ultima modificacion:",-40}{FechaUltModificacion:dd/MM/yyyy H:mm:ss}\n\r{"Numero de ultimo usuario que modifico: ",-40}{UsuarioUltModificacion}";

    }


}