namespace SGE.Aplicacion;

public class AutorizacionExcepcion : Exception
{
    public AutorizacionExcepcion() { }
    public AutorizacionExcepcion(string message) : base(message) { }

    // Preguntar inner
    // public AutorizacionExcepcion(string message, Exception inner) : base(message, inner) { }



}
