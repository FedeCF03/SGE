using SGE.Aplicacion;
using SGE.Repositorios;
/*
que hacer cuando se borran todos los tramites asociados a un expediente
Que hacer si catchea una excepcion de entrada salida
Funciona así el alcanze del using?
clases abstractas?

// tramite caso alto andando 10 puntitosss
//tramite modificacion andando 10 puntitosss
//tramite consulta etiqueta andando 10 puntitosss
//tramite borrado andando 10 puntitosss
expediente alta andando 10 puntitosss
expediente baja andando 10 puntitosss
expediente consulta por id andando 10 puntitosss
expediente consulta todos andando 10 puntitosss



*/
Expediente expediente1 = new("HOLA MUNDODODODODODO", 1, EstadoExpediente.Finalizado) { Id = 15 };
Expediente expediente2 = new(1, "123321", 1, EstadoExpediente.ReciénIniciado);
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
//CasoDeUsoTramiteAlta casoDeUsoTramiteAlta = new(new TramiteRepositorioTXT(), new ExpedienteRepositorioTXT(), new ServicioAutorizacionProvisorio());
//casoDeUsoTramiteAlta.Ejecutar(1, tramite1);
//CasoDeUsoExpedienteBaja casoDeUsoExpedienteBaja = new(new ExpedienteRepositorioTXT(), new TramiteRepositorioTXT(), new ServicioAutorizacionProvisorio());
//casoDeUsoExpedienteBaja.Ejecutar(1, 17);
CasoDeUsoExpedienteModificacion casoDeUsoExpedienteConsultaTodos = new(new ExpedienteRepositorioTXT(), new ServicioAutorizacionProvisorio());
casoDeUsoExpedienteConsultaTodos.Ejecutar(1, expediente1);