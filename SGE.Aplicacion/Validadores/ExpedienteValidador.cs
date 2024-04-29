namespace SGE.Aplicacion;

public class ExpedienteValidador
{
    public bool Validar(Expediente expediente, int usuario)
    {
        string message = "";
        if (expediente == null)
            message += "Debe ingresar un expediente validado";
        else
        {
            if (expediente.Caratula == "")
                message += "El contenido del expediente no puede estar vacío";
            if (usuario <= 0)
                message += "El ID del usuario tiene que ser mayor a 0";
        }
        if (message != "")
            throw new ValidacionException(message);
        return true;
        // es correcto devolver un bool y una excepcion, o solo con la excepcion es suficiente?
    }

}
