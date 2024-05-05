using SGE.Aplicacion;
using SGE.Repositorios;
/*
Que hacer si catchea una excepcion de entrada salida
Funciona así el alcanze del using?
pibe? te fuiste del ds
//caso alto andando 10 puntitosss
//modificacion andando 10 puntitosss
*/
Expediente expediente1 = new("fededsaasd", 1, EstadoExpediente.ReciénIniciado);
Expediente expediente2 = new("123321", 1, EstadoExpediente.ReciénIniciado);
Expediente expediente3 = new("54645756", 1, EstadoExpediente.ReciénIniciado);
Expediente expediente4 = new("feded6785878saasd", 1, EstadoExpediente.ReciénIniciado);
Expediente expediente5 = new("567657567", 1, EstadoExpediente.ReciénIniciado);
Expediente expediente6 = new("fed65735edsaasd", 1, EstadoExpediente.ReciénIniciado);
Expediente expediente7 = new("otmotmotmotmtitomitmotim", 1, EstadoExpediente.ReciénIniciado);
Expediente expediente8 = new("345", 1, EstadoExpediente.ReciénIniciado);
Tramite tramite1 = new(18, EtiquetaTramite.PaseAlArchivo, "contenido1", 1);
Tramite tramite2 = new(7, 16, EtiquetaTramite.PaseAlArchivo, "contenidoTomi", 69);
Tramite tramite3 = new(22, EtiquetaTramite.Resolución, "contenido3", 1);
Tramite tramite4 = new(21, EtiquetaTramite.PaseAlArchivo, "contenido4", 1);
// CasoDeUsoExpedienteAlta casoDeUsoExpedienteAlta = new(new ExpedienteRepositorioTXT(), new ServicioAutorizacionProvisorio());
//casoDeUsoExpedienteAlta.Ejecutar(1, expediente1);
CasoDeUsoTramiteAlta casoDeUsoTramiteAlta = new(new TramiteRepositorioTXT(), new ExpedienteRepositorioTXT(), new ServicioAutorizacionProvisorio());

casoDeUsoTramiteAlta.Ejecutar(1, tramite1);
Console.WriteLine("id  " + tramite1.Id);
CasoDeUsoTramiteModificacion casoDeUsoExpedienteModificacion = new(new TramiteRepositorioTXT(), new ServicioAutorizacionProvisorio());
