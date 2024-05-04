using SGE.Aplicacion;
using SGE.Repositorios;
/*
Que hacer si catchea una excepcion de entrada salida
*/
Expediente expediente1 = new("fededsaasd", 1, EstadoExpediente.ReciénIniciado);
Expediente expediente2 = new("123321", 1, EstadoExpediente.ReciénIniciado);
Expediente expediente3 = new("54645756", 1, EstadoExpediente.ReciénIniciado);
Expediente expediente4 = new("feded6785878saasd", 1, EstadoExpediente.ReciénIniciado);
Expediente expediente5 = new("567657567", 1, EstadoExpediente.ReciénIniciado);
Expediente expediente6 = new("fed65735edsaasd", 1, EstadoExpediente.ReciénIniciado);
Expediente expediente7 = new("otmotmotmotmtitomitmotim", 1, EstadoExpediente.ReciénIniciado);
Expediente expediente8 = new("345", 1, EstadoExpediente.ReciénIniciado);
Tramite tramite1 = new(108, EtiquetaTramite.Resolución, "contenido1", 1);
Tramite tramite2 = new(23, EtiquetaTramite.Resolución, "contenido2", 1);
Tramite tramite3 = new(22, EtiquetaTramite.Resolución, "contenido3", 1);
Tramite tramite4 = new(21, EtiquetaTramite.Resolución, "contenido4", 1);
// CasoDeUsoExpedienteAlta casoDeUsoExpedienteAlta = new(new ExpedienteRepositorioTXT(), new ServicioAutorizacionProvisorio());
// casoDeUsoExpedienteAlta.Ejecutar(1, expediente1);
CasoDeUsoTramiteAlta casoDeUsoTramiteAlta = new(new TramiteRepositorioTXT(), new ExpedienteRepositorioTXT(), new ServicioAutorizacionProvisorio());
casoDeUsoTramiteAlta.Ejecutar(1, tramite1);