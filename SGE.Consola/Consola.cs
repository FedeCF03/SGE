using SGE.Aplicacion;
using SGE.Repositorios;
/*
implementar consola
probar--
tema incrementar id
tema excepciones
validacion de datos
revisar impletacion de alta , baja , modificacion
preguntar modificacion
nombre archivo

setters privados
metodos privados, incrementarid
actualización de estado, vinculación de expediente con trámite
hacer todas clases de instancia, se podría hacer static?
*/
Expediente expediente = new("fededsaasd", 6, EstadoExpediente.ReciénIniciado);
CasoDeUsoExpedienteConsultaTodos casoDeUsoExpedienteAlta = new(new ExpedienteRepositorioTXT());
Console.WriteLine(casoDeUsoExpedienteAlta.Ejecutar().Count);