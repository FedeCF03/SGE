namespace SGE.Aplicacion;


public class Expediente
{
    public int Id { get; set; }
    public string Caratula { get; set; } = "";
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaUltModificacion { get; set; }
    public int UsuarioUltModificacion { get; set; }
    public EstadoExpediente Estado { get; set; } = EstadoExpediente.RecienIniciado;

    public List<Tramite> ListaTramites { get; set; } = [];

    public Expediente() { }

    public Expediente(string caratula)
    {
        Caratula = caratula;
    }

    public override string ToString()
    {
        return $"{"ID:",-40}{Id}\n\r{"Caratula:",-40}{Caratula}\n\r{"Fecha de creacion:",-40}{FechaCreacion:dd/MM/yyyy H:mm:ss}\n\r{"Fecha de ultima modificacion:",-40}{FechaUltModificacion:dd/MM/yyyy H:mm:ss}\n\r{"Numero del ultimo usuario que modifico:",-40}{UsuarioUltModificacion}\n\r{"Estado:",-40}{Estado}";

    }

    public string TramitesToString()
    {
        string strRet = ListaTramites.Count == 0 ? "No hay tramites asociados" : "Tramites asociados:\n\r";

        foreach (Tramite t in ListaTramites)
        {
            strRet += "------------------\n\r";
            strRet += t.ToString() + "\n\r";
        }
        return strRet;
    }
}