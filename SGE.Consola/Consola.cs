using SGE.Aplicacion;
using SGE.Repositorios;
/*
implementar consola
probar
tema incrementar id
tema excepciones
validacion de datos
revisar impletacion de alta



*/
Expediente expediente = new Expediente(20, "caratula", DateTime.Now, DateTime.Now, 1, EstadoExpediente.ReciénIniciado);

CasoDeUsoExpedienteAlta casoDeUsoExpedienteAlta = new CasoDeUsoExpedienteAlta(new ExpedienteRepositorioTXT(), new ServicioAutorizacionProvisorio(), new ExpedienteValidador());
casoDeUsoExpedienteAlta.Ejecutar(1, expediente);
CasoDeUsoExpedienteConsultaPorId casoDeUsoExpedienteConsultaPorId = new CasoDeUsoExpedienteConsultaPorId(new ExpedienteRepositorioTXT());
Expediente exp = casoDeUsoExpedienteConsultaPorId.Ejecutar(18);
Console.WriteLine($"Expediente: {exp.Id} - {exp.Caratula} - {exp.FechaCreacion} - {exp.FechaUltModificacion} - {exp.UsuarioUltModificacion} - {exp.Estado}");