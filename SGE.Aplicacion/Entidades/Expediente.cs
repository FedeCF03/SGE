namespace SGE.Aplicacion;

/*
Los valores posibles para establecer el estado de un expediente son los siguientes:
● Recién iniciado
● Para resolver 
● Con resolución
● En notificación
● Finalizado
ExpedienteAlta: Puede realizar altas de expedientes
● ExpedienteBaja: Puede realizar bajas de expedientes
● ExpedienteModificacion: Puede realizar modificaciones de expedientes
La carátula de un expediente no puede estar vacía
● El id de usuario (en trámites y expedientes) debe ser un id válido (entero mayor que 0)
Cuando la etiqueta del último trámite es "Resolución", se produce un cambio automático al estado
"Con resolución".
● Cuando la etiqueta del último trámite es "Pase a estudio", se produce un cambio automático al
estado "Para resolver".
● Cuando la etiqueta del último trámite es "Pase al Archivo", se produce un cambio automático al
estado "Finalizado".
Manejo de excepciones
desarrollar un caso de uso para listar todos los expedientes (sin incluir sus trámites)
cambio automático del estado de un expediente, se puede emplear la siguiente
estrategia: desarrollar un servicio que, a partir del Id de un expediente, recupere la etiqueta de su último
trámite. Basándose en esta información y conforme a las especificaciones detalladas en este documento,
dicho servicio realizará el cambio de estado del expediente cuando sea necesario. Este servicio podrá ser
invocado por los casos de uso correspondientes después de agregar, modificar o eliminar un trámite.
Además, resultaría beneficioso desacoplar el servicio de la especificación que define qué cambio de estado
debe llevarse a cabo en función de la etiqueta del último trámite. Esta especificación podría ser
suministrada al servicio mediante la técnica de inyección de dependencias
*/
public class Expediente
{
    // cada expediente asociado a un tramite???

    public int Id { get; set; }
    public string? Caratula { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaUltModificacion { get; set; }
    public int UsuarioUltModificacion { get; set; }
    public EstadoExpediente Estado { get; set; }


    public Expediente(int id, string? caratula, int usuario, EstadoExpediente estado)
    {
        Id = id;
        Caratula = caratula;
        FechaCreacion = DateTime.Now;
        FechaUltModificacion = FechaCreacion;
        Estado = estado;
        UsuarioUltModificacion = usuario;
    }

    public Expediente()
    {

    }

    public void Alta(IExpedienteRepositorio expediente)
    {
        throw new NotImplementedException();
    }

    public void Baja(IExpedienteRepositorio expediente)
    {
        throw new NotImplementedException();
    }

    public void Modificacion(IExpedienteRepositorio expediente)
    {
        throw new NotImplementedException();
    }
}