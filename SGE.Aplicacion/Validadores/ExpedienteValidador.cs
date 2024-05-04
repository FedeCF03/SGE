namespace SGE.Aplicacion;

public static class ExpedienteValidador
{
    public static bool Validar(Expediente expediente, int usuario)
    {
        if (expediente == null || expediente.Caratula == null || expediente.Caratula.Equals("") || (usuario <= 0))
            return false;
        return true;

    }

}
// Compare this snippet from SGE.Aplicacion/Validadores/ExpedienteValidador.cs: