using System.Collections;
using System.Diagnostics;
using SGE.Aplicacion;
using SGE.Repositorios;
ITramiteRepositorio tramiteRepo = new TramiteRepositorioTXT();
IExpedienteRepositorio expedienteRepo = new ExpedienteRepositorioTXT();
IServicioAutorizacion servicioAutorizacionProvisorio = new ServicioAutorizacionProvisorio();
IEspecificacionCambioDeEstado especificacionCambioDeEstado = new EspecificacionCambioDeEstado();
string continuar = "y";
while (continuar.Equals("y"))
{
    try
    {
        int idUsuario;
        string caratula;
        int idExpedienteBaja;
        Console.WriteLine("Para opciones de expediente, presione 1 ");
        Console.WriteLine("Para opciones de tramite, presione 2 ");
        Console.WriteLine("Para terminar el programa, presione 3");

        int i = int.Parse(Console.ReadLine() ?? "");
        if (i == 1)
        {
            Console.WriteLine("Para dar de alta un expediente, presione 1 ");
            Console.WriteLine("Para dar de baja un expediente, presione 2 ");
            Console.WriteLine("Para consultar un expediente por id, presione 3 ");
            Console.WriteLine("Para consultar todos los expedientes, presione 4 ");
            Console.WriteLine("Para modificar un expediente, presione 5 ");

            i = int.Parse(Console.ReadLine() ?? "");
            switch (i)
            {
                case 1:

                    Console.WriteLine("Ingrese el id del usuario");
                    idUsuario = int.Parse(Console.ReadLine() ?? "");
                    Console.WriteLine("Ingrese la caratula");
                    caratula = Console.ReadLine() ?? "";
                    Expediente expediente = new(caratula);
                    CasoDeUsoExpedienteAlta casoDeUsoExpedienteAlta = new(expedienteRepo, servicioAutorizacionProvisorio);
                    casoDeUsoExpedienteAlta.Ejecutar(idUsuario, expediente);
                    break;
                case 2:

                    Console.WriteLine("Ingrese el id del usuario");
                    idUsuario = int.Parse(Console.ReadLine() ?? "");
                    Console.WriteLine("Ingrese el id del expediente a dar de baja");
                    idExpedienteBaja = int.Parse(Console.ReadLine() ?? "");

                    CasoDeUsoExpedienteBaja casoDeUsoExpedienteBaja = new(expedienteRepo,
                    tramiteRepo,
                    servicioAutorizacionProvisorio);

                    casoDeUsoExpedienteBaja.Ejecutar(idUsuario, idExpedienteBaja);

                    break;
                case 3:

                    Console.WriteLine("Ingrese el id del expediente a consultar");
                    int idExpedienteConsulta = int.Parse(Console.ReadLine() ?? "");
                    CasoDeUsoExpedienteConsultaPorId casoDeUsoExpedienteConsultaPorId = new(expedienteRepo, tramiteRepo);
                    Expediente? expedienteRes = casoDeUsoExpedienteConsultaPorId.Ejecutar(idExpedienteConsulta,
                    out List<Tramite> listaTramites);

                    if (expedienteRes != null)
                    {
                        Console.WriteLine(expedienteRes.ToString());
                        Console.WriteLine("---------------------");
                        if (listaTramites.Count != 0)
                        {
                            Console.WriteLine("Tramites asociados: ");
                            Console.WriteLine("---------------------");
                            foreach (Tramite t in listaTramites)
                            {
                                Console.WriteLine(t.ToString());
                                Console.WriteLine("---------------------");
                            }
                        }
                        else
                            Console.WriteLine("No hay tramites asociados");
                    }

                    break;
                case 4:

                    CasoDeUsoExpedienteConsultaTodos casoDeUsoExpedienteConsultaTodos = new(expedienteRepo);
                    List<Expediente>? listaExpedientes = casoDeUsoExpedienteConsultaTodos.Ejecutar();
                    if (listaExpedientes != null)
                        foreach (Expediente e in listaExpedientes)
                        {
                            Console.WriteLine(e.ToString());
                        }
                    break;
                case 5:

                    Console.WriteLine("Ingrese el id del usuario");
                    idUsuario = int.Parse(Console.ReadLine() ?? "");
                    Console.WriteLine("Ingrese el id del expediente a modificar");
                    int idExpedienteModificacion = int.Parse(Console.ReadLine() ?? "");
                    Console.WriteLine("Ingrese la caratula nueva");
                    caratula = Console.ReadLine() ?? "";
                    Expediente expedienteModificacion = new(caratula) { Id = idExpedienteModificacion };
                    CasoDeUsoExpedienteModificacion casoDeUsoExpedienteModificacion = new(expedienteRepo, servicioAutorizacionProvisorio);
                    casoDeUsoExpedienteModificacion.Ejecutar(idUsuario, expedienteModificacion);
                    break;
            }

        }
        else if (i == 2)
        {
            Console.WriteLine("Para dar de alta un trámite, presione 1 ");
            Console.WriteLine("Para dar de baja un trámite, presione 2 ");
            Console.WriteLine("Para consultar un trámite por etiqueta, presione 3 ");
            Console.WriteLine("Para modificar un tramite, presione 4 ");
            i = int.Parse(Console.ReadLine() ?? "");
            Tramite tramite;
            switch (i)
            {
                case 1:
                    int usuario;


                    Console.WriteLine("Ingrese su numero de usuario");
                    usuario = int.Parse(Console.ReadLine() ?? "");
                    tramite = new();

                    Console.WriteLine("Ingrese id del expediente correspondiente");
                    tramite.ExpedienteId = int.Parse(Console.ReadLine() ?? "");

                    Console.WriteLine("Ingrese la etiqueta del trámite");
                    tramite.Etiqueta = (EtiquetaTramite)Enum.Parse(typeof(EtiquetaTramite), Console.ReadLine() ?? "", true);

                    Console.WriteLine("Ingrese el contenido del trámite");
                    tramite.Contenido = Console.ReadLine() ?? "";

                    CasoDeUsoTramiteAlta casoDeUsoTramiteAlta = new(tramiteRepo, expedienteRepo, servicioAutorizacionProvisorio, especificacionCambioDeEstado);
                    casoDeUsoTramiteAlta.Ejecutar(usuario, tramite);

                    break;
                case 2:
                    Console.WriteLine("Ingrese el id del usuario");
                    idUsuario = int.Parse(Console.ReadLine() ?? "");
                    Console.WriteLine("Ingrese el id del tramite a dar de baja");
                    int idTramiteBaja = int.Parse(Console.ReadLine() ?? "");
                    CasoDeUsoTramiteBaja casoDeUsoTramiteBaja = new(tramiteRepo, expedienteRepo, servicioAutorizacionProvisorio, especificacionCambioDeEstado);
                    casoDeUsoTramiteBaja.Ejecutar(idUsuario, idTramiteBaja);
                    break;
                case 3:
                    Console.WriteLine("Ingrese la etiqueta del tramite a consultar");
                    EtiquetaTramite etiquetaTramiteConsulta = (EtiquetaTramite)Enum.Parse(typeof(EtiquetaTramite), Console.ReadLine() ?? "", true);
                    CasoDeUsoTramiteConsultaPorEtiqueta casoDeUsoTramiteConsultaPorEtiqueta = new(tramiteRepo);
                    List<Tramite> listaTramites = casoDeUsoTramiteConsultaPorEtiqueta.Ejecutar(etiquetaTramiteConsulta);
                    if (listaTramites.Count > 0)
                    {
                        foreach (Tramite t in listaTramites)
                        {
                            Console.WriteLine(t.ToString());
                            Console.WriteLine("---------------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontraron tramites con esa etiqueta");
                    }
                    break;
                case 4:
                    Console.WriteLine("Ingrese el id del usuario");
                    idUsuario = int.Parse(Console.ReadLine() ?? "");
                    tramite = new();
                    CasoDeUsoTramiteModificacion casoDeUsoTramiteModificacion = new(tramiteRepo, expedienteRepo, servicioAutorizacionProvisorio, especificacionCambioDeEstado);

                    Console.WriteLine("Ingrese el id del tramite a modificar");
                    tramite.Id = int.Parse(Console.ReadLine() ?? "");

                    Console.WriteLine("Ingrese el id del expediente correspondiente");
                    tramite.ExpedienteId = int.Parse(Console.ReadLine() ?? "");

                    Console.WriteLine("Ingrese la etiqueta del tramite");
                    tramite.Etiqueta = (EtiquetaTramite)Enum.Parse(typeof(EtiquetaTramite), Console.ReadLine() ?? "", true);

                    Console.WriteLine("Ingrese el contenido del tramite");
                    tramite.Contenido = Console.ReadLine() ?? "";

                    casoDeUsoTramiteModificacion.Ejecutar(idUsuario, tramite);
                    break;
            }
        }

    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);

    }
    finally
    {
        Console.WriteLine("¿Desea continuar? y/n");
        continuar = Console.ReadLine() ?? "n";
    }
}