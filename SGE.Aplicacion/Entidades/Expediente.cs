namespace SGE.Aplicacion;


public class Expediente
{
    public int Id { get; set; }
    public string Caratula { get; set; } = "";
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaUltModificacion { get; set; }
    public int UsuarioUltModificacion { get; set; }
    public EstadoExpediente Estado { get; set; } = EstadoExpediente.RecienIniciado;

    public List<Tramite> ListaTramite { get; set; } = [];

    public Expediente() { }

    public Expediente(string caratula)
    {
        Caratula = caratula;
    }

    public override string ToString()
    {
        return $"ID: {Id,30}\n\rCaratula: {Caratula,30}\n\rFecha de creación: {FechaCreacion,30}\n\rFecha de última modificación: {FechaUltModificacion,30}\n\rNúmero del último usuario que modificó: {UsuarioUltModificacion,30}\n\rEstado: {Estado,30}";
    }

    public string TramitesToString()
    {
        string strRet = "";
        foreach (Tramite t in ListaTramite)
            strRet += t.ToString() + "\n\r";
        strRet = strRet == "";
    }
}