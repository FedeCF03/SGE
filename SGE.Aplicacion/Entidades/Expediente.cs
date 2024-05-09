namespace SGE.Aplicacion;


public class Expediente
{
    public int Id { get; set; }
    public string Caratula { get; set; } = "";
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaUltModificacion { get; set; }
    public int UsuarioUltModificacion { get; set; }
    public EstadoExpediente Estado { get; set; }

    public Expediente() { }

    public Expediente(string caratula, int idUsuario, EstadoExpediente estado)
    {
        Caratula = caratula;
        UsuarioUltModificacion = idUsuario;
        Estado = estado;
    }
    public Expediente(int id, string caratula, int idUsuario, EstadoExpediente estado) : this(caratula, idUsuario, estado)
    {
        Id = id;
    }
    public Expediente(int id, string caratula, DateTime fechaCreacion, DateTime fechaUltModificacin, int idUsuario, EstadoExpediente estado) : this(caratula, idUsuario, estado)
    {
        Id = id;
        FechaCreacion = fechaCreacion;
        FechaUltModificacion = fechaUltModificacin;
    }

    public override string ToString()
    {
        return $"Id: {Id}\n\rCaratula: {Caratula}\n\rFechaCreacion: {FechaCreacion}\n\rFechaUltModificacion: {FechaUltModificacion}\n\rUsuarioUltModificacion: {UsuarioUltModificacion}\n\rEstado: {Estado}";
    }

}