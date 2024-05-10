namespace SGE.Aplicacion;



public abstract class Documento
{
    public int Id { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaUltModificacion { get; set; }
    public int UsuarioUltModificacion { get; set; }


}