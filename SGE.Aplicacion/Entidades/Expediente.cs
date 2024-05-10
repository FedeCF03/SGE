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

    public Expediente(string caratula, EstadoExpediente estado)
    {
        Caratula = caratula;
        Estado = estado;
    }
    public Expediente(int id, string caratula, int idUsuario, EstadoExpediente estado) : this(caratula, estado)
    {
        Id = id;
    }
    public Expediente(int id, string caratula, DateTime fechaCreacion, DateTime fechaUltModificacin, EstadoExpediente estado) : this(caratula, estado)
    {
        Id = id;
        FechaCreacion = fechaCreacion;
        FechaUltModificacion = fechaUltModificacin;
    }

    public override string ToString()
    {
        return $"Id: {Id}\n\rCaratula: {Caratula}\n\rFecha de creación: {FechaCreacion}\n\rFecha de última modificación: {FechaUltModificacion}\n\rNúmero del último usuario que modificó: {UsuarioUltModificacion}\n\rEstado: {Estado}";
    }

}