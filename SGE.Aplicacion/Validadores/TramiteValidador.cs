namespace SGE.Aplicacion;
public static class TramiteValidador
{
    public static bool Validar(Tramite tramite, int usuario)
    {
        if (tramite == null || tramite.Contenido == null || tramite.Contenido.Equals("") || (usuario <= 0))
            return false;
        return true;

    }

}