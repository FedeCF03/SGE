namespace SGE.Repositorios;

using System.Collections.Generic;
using System.Data;
using SGE.Aplicacion;

public class TramiteRepositorioTXT : ITramiteRepositorio
{
    // como implementar el autoincremento de id; 
    readonly string NombreIds = "idTramites.txt";
    readonly string NombreArch = "tramites.txt";
    readonly string NombreArchAux = "auxiliar_tramites.txt";

    public TramiteRepositorioTXT()
    {
        if (!File.Exists(NombreIds))
        {
            using var sw = new StreamWriter(NombreIds);
            sw.WriteLine(1);
        }
        if (!File.Exists(NombreArch))
        {
            using var sw = new StreamWriter(NombreArch);
        }
    }
    public void Alta(Tramite tramite)
    {
        using var sw = new StreamWriter(NombreArch, true);

        {
            tramite.Id = DevolverIdInc();
            sw.WriteLine(tramite.Id);
            sw.WriteLine(tramite.ExpedienteId);
            sw.WriteLine(tramite.Etiqueta);
            sw.WriteLine(tramite.Contenido);
            sw.WriteLine(tramite.FechaCreacion);
            sw.WriteLine(tramite.FechaUltModificacion);
            sw.WriteLine(tramite.UsuarioUltModificacion);
        }

    }

    public int Baja(int idTramite)
    {
        try
        {
            int id = -1;
            int idExpediente = -1;

            {
                using StreamReader sr = new(NombreArch);
                using StreamWriter sw = new(NombreArchAux);
                while (!sr.EndOfStream && (id = int.Parse(sr.ReadLine() ?? "")) != idTramite)
                {
                    if (id != idTramite)
                    {
                        sw.WriteLine(id);
                        sw.WriteLine(sr.ReadLine() ?? "");
                        sw.WriteLine(sr.ReadLine() ?? "");
                        sw.WriteLine(sr.ReadLine() ?? "");
                        sw.WriteLine(sr.ReadLine() ?? "");
                        sw.WriteLine(sr.ReadLine() ?? "");
                        sw.WriteLine(sr.ReadLine() ?? "");

                    }
                }
                if (!sr.EndOfStream)
                {
                    idExpediente = int.Parse(sr.ReadLine() ?? "");
                    sr.ReadLine();
                    sr.ReadLine();
                    sr.ReadLine();
                    sr.ReadLine();
                    sr.ReadLine();
                    sw.Write(sr.ReadToEnd());
                }
            }

            if (id == idTramite)
            {
                Console.WriteLine(idExpediente);
                File.Move(NombreArchAux, NombreArch, true);
                return idExpediente;
            }
            else
                return -1;
        }
        catch (Exception e)
        {

            Console.WriteLine(e.Message);
            return -1;
        }
    }
    public bool BorrarTodosDeIdExpediente(int expedienteId)
    {
        try
        {
            int idExp;
            int id;
            {
                using StreamReader sr = new(File.OpenRead(NombreArch));
                using StreamWriter sw = new(NombreArchAux);

                while (!sr.EndOfStream)
                {
                    id = int.Parse(sr.ReadLine() ?? "-1");
                    idExp = int.Parse(sr.ReadLine() ?? "-1");
                    if (idExp != expedienteId)
                    {
                        sw.WriteLine(id);
                        sw.WriteLine(idExp);
                        sw.WriteLine(sr.ReadLine() ?? "");
                        sw.WriteLine(sr.ReadLine() ?? "");
                        sw.WriteLine(sr.ReadLine() ?? "");
                        sw.WriteLine(sr.ReadLine() ?? "");
                        sw.WriteLine(sr.ReadLine() ?? "");
                    }
                    else
                    {
                        for (int i = 0; i < 5; i++)
                            sr.ReadLine();
                    }
                }
            }
            File.Move(NombreArchAux, NombreArch, true);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Hubo un en mi");
            Console.WriteLine(e.Message);
            return false;
        }
    }


    public Tramite? BuscarPorId(int idTramite)
    {
        Tramite auxiliar = new();
        try
        {
            using StreamReader sr = new(NombreArch);
            while (!sr.EndOfStream && ((auxiliar.Id = int.Parse(sr.ReadLine() ?? "-1")) != idTramite))
            {
                for (int i = 0; i < 6; i++)
                    sr.ReadLine();
            }
            if (auxiliar.Id == idTramite)
            {
                auxiliar.ExpedienteId = int.Parse(sr.ReadLine() ?? "");
                auxiliar.Etiqueta = (EtiquetaTramite)Enum.Parse(typeof(EtiquetaTramite), sr.ReadLine() ?? "");
                auxiliar.Contenido = sr.ReadLine();
                auxiliar.FechaCreacion = DateTime.Parse(sr.ReadLine() ?? "");
                auxiliar.FechaUltModificacion = DateTime.Parse(sr.ReadLine() ?? "");
                auxiliar.UsuarioUltModificacion = int.Parse(sr.ReadLine() ?? "");
                return auxiliar;
            }
            else
                return null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }
    public int DevolverIdInc()
    {
        try
        {
            int id;
            using (StreamReader sr = new(NombreIds))
            {
                id = int.Parse(sr.ReadLine() ?? "");
            }
            using (StreamWriter sw = new(NombreIds))
            {
                sw.WriteLine(id + 1);
            }
            return id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return -1;
        }
    }


    public List<Tramite>? Listar()
    {
        try
        {
            List<Tramite> lista = [];

            using var sr = new StreamReader(File.OpenRead(NombreArch));

            while (!sr.EndOfStream)
            {
                Tramite auxiliar = new Tramite()
                {
                    Id = int.Parse(sr.ReadLine() ?? "-1"),
                    ExpedienteId = int.Parse(sr.ReadLine() ?? ""),
                    Etiqueta = (EtiquetaTramite)Enum.Parse(typeof(EtiquetaTramite), sr.ReadLine() ?? ""),
                    Contenido = sr.ReadLine(),
                    FechaCreacion = DateTime.Parse(sr.ReadLine() ?? ""),
                    FechaUltModificacion = DateTime.Parse(sr.ReadLine() ?? ""),
                    UsuarioUltModificacion = int.Parse(sr.ReadLine() ?? "")
                };
                lista.Add(auxiliar);

            }
            return lista;

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }


    public List<Tramite>? ListarPorEtiqueta(EtiquetaTramite etiqueta)
    {
        List<Tramite> lista = [];
        try
        {
            using var sr = new StreamReader(NombreArch);

            while (!sr.EndOfStream)
            {
                Tramite auxiliar = new()
                {
                    Id = int.Parse(sr.ReadLine() ?? ""),
                    ExpedienteId = int.Parse(sr.ReadLine() ?? ""),
                    Etiqueta = (EtiquetaTramite)Enum.Parse(typeof(EtiquetaTramite), sr.ReadLine() ?? ""),
                    Contenido = sr.ReadLine(),
                    FechaCreacion = DateTime.Parse(sr.ReadLine() ?? ""),
                    FechaUltModificacion = DateTime.Parse(sr.ReadLine() ?? ""),
                    UsuarioUltModificacion = int.Parse(sr.ReadLine() ?? "")
                };
                if (auxiliar.Etiqueta == etiqueta)
                    lista.Add(auxiliar);
            }

            return lista;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }


    }
    //Modifica el trámite en el archivo de texto y devuelve la etiqueta del trámite antes de ser modificado
    public bool Modificar(Tramite tramite)
    {
        int id = -1;
        try
        {
            //Funciona así el alcanze del using?
            {
                using StreamWriter sw = new(NombreArchAux);
                using StreamReader sr = new(NombreArch);
                while (!sr.EndOfStream && (id = int.Parse(sr.ReadLine() ?? "")) != tramite.Id)
                {
                    sw.WriteLine(id);
                    sw.WriteLine(sr.ReadLine() ?? "");
                    sw.WriteLine(sr.ReadLine() ?? "");
                    sw.WriteLine(sr.ReadLine() ?? "");
                    sw.WriteLine(sr.ReadLine() ?? "");
                    sw.WriteLine(sr.ReadLine() ?? "");
                    sw.WriteLine(sr.ReadLine() ?? "");
                }
                if (id == tramite.Id)
                {
                    sw.WriteLine(id);
                    sw.WriteLine(tramite.ExpedienteId);
                    sw.WriteLine(tramite.Etiqueta);
                    sw.WriteLine(tramite.Contenido);
                    sw.WriteLine(tramite.FechaCreacion);
                    sw.WriteLine(tramite.FechaUltModificacion);
                    sw.WriteLine(tramite.UsuarioUltModificacion);

                    for (int i = 0; i < 7; i++)
                        sr.ReadLine();
                    sw.Write(sr.ReadToEnd());
                }
            }

            if (id == tramite.Id)
                File.Move(NombreArchAux, NombreArch, true);
            else
                File.Delete(NombreArchAux);

            return id == tramite.Id;


        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;

        }


    }


    public Tramite? BuscarUltimo(int idExpediente)
    {
        Tramite resultado = new() { Id = -1 };
        Tramite auxiliar = new();
        try
        {
            using var sr = new StreamReader(NombreArch);
            while (!sr.EndOfStream)
            {
                auxiliar.Id = int.Parse(sr.ReadLine() ?? "");
                auxiliar.ExpedienteId = int.Parse(sr.ReadLine() ?? "");
                if (auxiliar.ExpedienteId == idExpediente)
                {
                    resultado.Etiqueta = (EtiquetaTramite)Enum.Parse(typeof(EtiquetaTramite), sr.ReadLine() ?? "");
                    resultado.Contenido = sr.ReadLine() ?? "";
                    resultado.FechaCreacion = DateTime.Parse(sr.ReadLine() ?? "");
                    resultado.FechaUltModificacion = DateTime.Parse(sr.ReadLine() ?? "");
                    resultado.UsuarioUltModificacion = int.Parse(sr.ReadLine() ?? "");
                    resultado.ExpedienteId = auxiliar.ExpedienteId;
                    resultado.Id = auxiliar.Id;
                    Console.WriteLine("tramite encontrado");
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                        sr.ReadLine();
                }

            }
            if (resultado.Id != -1)
                return resultado;
            return null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }


}
