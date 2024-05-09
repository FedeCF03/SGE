namespace SGE.Aplicacion;

public static class ExpedienteValidador
{
    public static bool Validar(Expediente? expediente, int usuario, out string mensajeError)
    {
        // if (expediente == null || string.IsNullOrWhiteSpace(expediente.Caratula) || (usuario <= 0))
        //     return false;
        // return true;

        mensajeError = "";
        if (expediente == null)
        {
            mensajeError = "El expediente no puede ser nulo.";
            return false;
        }
        if (string.IsNullOrWhiteSpace(expediente.Caratula))
        {
            mensajeError = "Nombre del producto inválido.\n";
        }
        if (usuario <= 0)
        {
            mensajeError += "El numero de usuario debe ser mayor que cero.\n";
        }

        return (mensajeError == "");
    }

}
// Compare this snippet from SGE.Aplicacion/Validadores/ExpedienteValidador.cs: