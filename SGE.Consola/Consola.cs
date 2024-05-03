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
Expediente expediente = new Expediente("holasdf", 5, EstadoExpediente.ReciénIniciado);

CasoDeUsoExpedienteAlta casoDeUsoExpedienteAlta = new CasoDeUsoExpedienteAlta(new ExpedienteRepositorioTXT(), new ServicioAutorizacionProvisorio(), new ExpedienteValidador());
casoDeUsoExpedienteAlta.Ejecutar(1, expediente);
