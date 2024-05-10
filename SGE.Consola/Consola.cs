﻿using System.Collections;
using System.Diagnostics;
using SGE.Aplicacion;
using SGE.Repositorios;
/*
esta bien tener un constructor con todos los parametrosde la clase?

que hacer cuando se borran todos los tramites asociados a un expediente
Que hacer si catchea una excepcion de entrada salida
clases abstractas?
tramite caso alto andando 10 puntitosss
tramite modificacion andando 10 puntitosss
tramite consulta etiqueta andando 10 puntitosss
tramite borrado andando 10 puntitosss
expediente alta andando 10 puntitosss
expediente baja andando 10 puntitosss
expediente consulta por id andando 10 puntitosss
expediente consulta todos andando 10 puntitosss
esta bien usar try catch en servicio actualizacion estado?
esta bien el try catch en la consola?
si no hay entidades a mostrar se devuelve una lista vacía o null?
esta bien actualizar los ids y las fechas en el objeto expediente/tramite que se pasa por parametro además de escribirlas en el texto?
*/


/*
string continuar = "y";
while (continuar.Equals("y"))
{
    Console.WriteLine("Para opciones de expediente, presione 1 ");
    Console.WriteLine("Para opciones de trámite, presione 2 ");
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
                int idUsuario = int.Parse(Console.ReadLine() ?? "");
                Console.WriteLine("Ingrese la caratula");
                string caratula = Console.ReadLine() ?? "";
                Console.WriteLine("Ingrese el estado del expediente");
                EstadoExpediente estado = (EstadoExpediente)Enum.Parse(typeof(EstadoExpediente), Console.ReadLine() ?? "", true);
                Expediente expediente = new(caratula, idUsuario, estado);
                CasoDeUsoExpedienteAlta casoDeUsoExpedienteAlta = new(new ExpedienteRepositorioTXT(), new ServicioAutorizacionProvisorio());
                casoDeUsoExpedienteAlta.Ejecutar(idUsuario, expediente);
                break;
            case 2:
                Console.WriteLine("Ingrese el id del usuario");
                idUsuario = int.Parse(Console.ReadLine() ?? "");
                Console.WriteLine("Ingrese el id del expediente a dar de baja");
                int idExpedienteBaja = int.Parse(Console.ReadLine() ?? "");
                CasoDeUsoExpedienteBaja casoDeUsoExpedienteBaja = new(new ExpedienteRepositorioTXT(), new TramiteRepositorioTXT(), new ServicioAutorizacionProvisorio());
                casoDeUsoExpedienteBaja.Ejecutar(idUsuario, idExpedienteBaja);
                break;
            case 3:
                Console.WriteLine("Ingrese el id del usuario");
                idUsuario = int.Parse(Console.ReadLine() ?? "");
                Console.WriteLine("Ingrese el id del expediente a consultar");
                int idExpedienteConsulta = int.Parse(Console.ReadLine() ?? "");
                CasoDeUsoExpedienteConsultaPorId casoDeUsoExpedienteConsultaPorId = new(new ExpedienteRepositorioTXT(), new TramiteRepositorioTXT());
                Expediente? expedienteRes = casoDeUsoExpedienteConsultaPorId.Ejecutar(idExpedienteConsulta, out List<Tramite>? listaTramites);
                if (expedienteRes != null)
                {
                    Console.WriteLine(expedienteRes.ToString());
                    Console.WriteLine("---------------------");
                    if (listaTramites?.Count == 0)
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
                        Console.WriteLine("No hay trámites asociados");

                }
                break;
            case 4:
                Console.WriteLine(Path.GetFullPath("Expedientes.txt"));
                Console.WriteLine("Ingrese el id del usuario");
                idUsuario = int.Parse(Console.ReadLine() ?? "");
                CasoDeUsoExpedienteConsultaTodos casoDeUsoExpedienteConsultaTodos = new(new ExpedienteRepositorioTXT());
                List<Expediente>? listaExpedientes = casoDeUsoExpedienteConsultaTodos.Ejecutar(idUsuario);
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
                Console.WriteLine("Ingrese la caratula");
                caratula = Console.ReadLine() ?? "";
                Console.WriteLine("Ingrese el estado del expediente");
                estado = (EstadoExpediente)Enum.Parse(typeof(EstadoExpediente), Console.ReadLine() ?? "", true);
                Expediente expedienteModificacion = new(idExpedienteModificacion, caratula, idUsuario, estado);
                CasoDeUsoExpedienteModificacion casoDeUsoExpedienteModificacion = new(new ExpedienteRepositorioTXT(), new ServicioAutorizacionProvisorio());
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

                Console.WriteLine("Ingrese su número de usuario");
                usuario = int.Parse(Console.ReadLine() ?? "");
                tramite = new();

                Console.WriteLine("Ingrese id del expediente correspondiente");
                tramite.ExpedienteId = int.Parse(Console.ReadLine() ?? "");

                Console.WriteLine("Ingrese la etiqueta del trámite");
                tramite.Etiqueta = (EtiquetaTramite)Enum.Parse(typeof(EtiquetaTramite), Console.ReadLine() ?? "", true);

                Console.WriteLine("Ingrese el contenido del trámite");
                tramite.Contenido = Console.ReadLine() ?? "";

                CasoDeUsoTramiteAlta casoDeUsoTramiteAlta = new(new TramiteRepositorioTXT(), new ExpedienteRepositorioTXT(), new ServicioAutorizacionProvisorio());
                casoDeUsoTramiteAlta.Ejecutar(usuario, tramite);
                break;
            case 2:
                Console.WriteLine("Ingrese el id del usuario");
                int idUsuario = int.Parse(Console.ReadLine() ?? "");
                Console.WriteLine("Ingrese el id del trámite a dar de baja");
                int idTramiteBaja = int.Parse(Console.ReadLine() ?? "");
                CasoDeUsoTramiteBaja casoDeUsoTramiteBaja = new(new TramiteRepositorioTXT(), new ExpedienteRepositorioTXT(), new ServicioAutorizacionProvisorio());
                casoDeUsoTramiteBaja.Ejecutar(idUsuario, idTramiteBaja);
                break;
            case 3:
                Console.WriteLine("Ingrese la etiqueta del trámite a consultar");
                EtiquetaTramite etiquetaTramiteConsulta = (EtiquetaTramite)Enum.Parse(typeof(EtiquetaTramite), Console.ReadLine() ?? "", true);
                CasoDeUsoTramiteConsultaPorEtiqueta casoDeUsoTramiteConsultaPorEtiqueta = new(new TramiteRepositorioTXT());
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
                    Console.WriteLine("No se encontraron trámites con esa etiqueta");
                }
                break;
            case 4:
                Console.WriteLine("Ingrese el id del usuario");
                idUsuario = int.Parse(Console.ReadLine() ?? "");
                tramite = new();
                CasoDeUsoTramiteModificacion casoDeUsoTramiteModificacion = new(new TramiteRepositorioTXT(), new ExpedienteRepositorioTXT(), new ServicioAutorizacionProvisorio());

                Console.WriteLine("Ingrese el id del trámite a modificar");
                tramite.Id = int.Parse(Console.ReadLine() ?? "");

                Console.WriteLine("Ingrese el id del expediente correspondiente");
                tramite.ExpedienteId = int.Parse(Console.ReadLine() ?? "");

                Console.WriteLine("Ingrese la etiqueta del trámite");
                tramite.Etiqueta = (EtiquetaTramite)Enum.Parse(typeof(EtiquetaTramite), Console.ReadLine() ?? "", true);

                Console.WriteLine("Ingrese el contenido del trámite");
                tramite.Contenido = Console.ReadLine() ?? "";

                casoDeUsoTramiteModificacion.Ejecutar(idUsuario, tramite);
                break;
        }
    }
    else
    {
        Console.WriteLine("Opción inválida");

        Console.WriteLine("¿Desea continuar? y/n");
        continuar = Console.ReadLine() ?? "n";

    }
    */

CasoDeUsoExpedienteAlta casoDeUsoExpedienteAlta = new(new ExpedienteRepositorioTXT(), new ServicioAutorizacionProvisorio());
Expediente expediente = new("caratula", EstadoExpediente.RecienIniciado);
casoDeUsoExpedienteAlta.Ejecutar(1, expediente);

CasoDeUsoExpedienteConsultaPorId casoDeUsoExpedienteConsultaPorId = new(new ExpedienteRepositorioTXT(), new TramiteRepositorioTXT());

Expediente? expedienteRes = casoDeUsoExpedienteConsultaPorId.Ejecutar(expediente.Id, out List<Tramite>? listaTramites);
Console.WriteLine("---------------------");

Console.WriteLine(expedienteRes?.ToString() ?? "");
if (listaTramites != null)
{
    if (listaTramites.Count > 0)
    {
        Console.WriteLine("Tramites asociados: ");
        foreach (Tramite t in listaTramites)
        {
            Console.WriteLine(t.ToString());
        }
    }
    else Console.WriteLine("No hay trámites asociados");
}
Console.WriteLine("---------------------");

CasoDeUsoTramiteAlta casoDeUsoTramiteAlta = new(new TramiteRepositorioTXT(), new ExpedienteRepositorioTXT(), new ServicioAutorizacionProvisorio());
Tramite tramite = new(expediente.Id, EtiquetaTramite.Resolucion, "contenido"); // Creo un trámite
casoDeUsoTramiteAlta.Ejecutar(1, tramite);

Expediente expediente2 = new("caratula2", EstadoExpediente.RecienIniciado);
casoDeUsoExpedienteAlta.Ejecutar(1, expediente2);


Console.WriteLine("---------------------");

CasoDeUsoExpedienteConsultaTodos casoDeUsoExpedienteConsultaTodos = new(new ExpedienteRepositorioTXT());
List<Expediente>? listaExpedientes = casoDeUsoExpedienteConsultaTodos.Ejecutar(); //Consulto los ids
if (listaExpedientes != null)
{
    if (listaExpedientes.Count > 0)
    {
        Console.WriteLine("Expedientes: ");
        foreach (Expediente e in listaExpedientes)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine(e.ToString());
        }
    }
    else Console.WriteLine("No hay expedientes");
}
Console.WriteLine("---------------------");

CasoDeUsoExpedienteBaja casoDeUsoExpedienteBaja = new(new ExpedienteRepositorioTXT(), new TramiteRepositorioTXT(), new ServicioAutorizacionProvisorio());
casoDeUsoExpedienteBaja.Ejecutar(1, expediente.Id);

listaExpedientes = casoDeUsoExpedienteConsultaTodos.Ejecutar();
if (listaExpedientes != null)
    foreach (Expediente e in listaExpedientes)
    {
        Console.WriteLine(e.ToString());
    }
Console.WriteLine("---------------------");
