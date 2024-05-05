namespace SGE.Aplicacion;



public abstract class Documento
{
    public int Id { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public DateTime FechaUltModificacion { get; set; } = DateTime.Now;
    public int UsuarioUltModificacion { get; set; }


}