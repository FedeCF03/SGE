namespace SGE.Aplicacion;
public class TramiteValidador
{
    public static bool Validar(Tramite? tramite, int usuario, out string mensajeError)
    {
        mensajeError = "";
        if (tramite == null)
        {
            mensajeError += "El tramite no puede ser nulo.";
            return false;
        }
        if (string.IsNullOrWhiteSpace(tramite.Contenido))
        {
            mensajeError += "El contenido del tramite no puede estar vacio.";
        }
        if (usuario <= 0)
        {
            mensajeError += "El numero de usuario debe ser mayor que cero.";
        }
        return (mensajeError == "");
    }
}