using SGE.Aplicacion;
using SGE.Repositorios;
/*
implementar consola
probar
tema incrementar id
tema excepciones
validacion de datos
revisar impletacion de alta
preguntar modificacion
*/
Expediente expediente = new("fededsaasd", 6, EstadoExpediente.ReciénIniciado);
CasoDeUsoExpedienteConsultaTodos casoDeUsoExpedienteAlta = new(new ExpedienteRepositorioTXT());
Console.WriteLine(casoDeUsoExpedienteAlta.Ejecutar().Count);