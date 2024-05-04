namespace SGE.Repositorios;

using System.Collections.Generic;
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
            using StreamReader sr = new StreamReader(File.OpenRead(NombreArch));
            {
                File.Create(NombreArchAux);
                using StreamWriter sw = new StreamWriter(NombreArchAux);
                {
                    while (!sr.EndOfStream && (id = int.Parse(sr.ReadLine() ?? "")) != idTramite)
                    {
                        if (id != idTramite)
                        {
                            sw.WriteLine(id);
                            idExpediente = int.Parse(sr.ReadLine() ?? "");
                            sw.WriteLine(idExpediente);
                            sw.WriteLine(sr.ReadLine() ?? "");
                            sw.WriteLine(sr.ReadLine() ?? "");
                            sw.WriteLine(sr.ReadLine() ?? "");
                            sw.WriteLine(sr.ReadLine() ?? "");
                        }
                    }
                    if (!sr.EndOfStream)
                    {
                        sr.ReadLine();
                        sr.ReadLine();
                        sr.ReadLine();
                        sr.ReadLine();
                        sr.ReadLine();
                        sw.WriteLine(sr.ReadToEnd());
                    }

                }
            }
            if (!sr.EndOfStream && id == idTramite)
            {
                File.Move(NombreArchAux, NombreArch, true);
                return id;
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
    public void BorrarTodosDeIdExpediente(int expedienteId)
    {
        try
        {
            int id = -1;
            File.Create(NombreArchAux);
            using StreamReader sr = new(File.OpenRead(NombreArch));
            using StreamWriter sw = new(NombreArchAux);

            while (!sr.EndOfStream)
            {
                id = int.Parse(sr.ReadLine() ?? "");
                if (id != expedienteId)
                {
                    sw.WriteLine(id);
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
            sw.Close();
            sr.Close();
            if (id == expedienteId)
                File.Move(NombreArchAux, NombreArch, true);
        }
        catch (Exception e)
        {

            Console.WriteLine(e.Message);
        }
    }


    public Tramite? BuscarPorId(int idTramite)
    {
        Tramite auxiliar = new();
        try
        {
            using StreamReader sr = new(NombreArch);
            while (!sr.EndOfStream && ((auxiliar.Id = int.Parse(sr.ReadLine() ?? "")) != idTramite))
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
                    Id = int.Parse(sr.ReadLine() ?? ""),
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

    public bool Modificar(Tramite tramite)
    {
        int n = 0;
        using StreamReader sr = new(NombreArch);
        using StreamWriter sw = new(NombreArch);
        while (!sr.EndOfStream && (n = int.Parse(sr.ReadLine() ?? "")) != tramite.Id)
        {
            for (int i = 0; i < 6; i++)
                sr.ReadLine();
        }

        if (n == tramite.Id)
        {
            sw.WriteLine(tramite.ExpedienteId);
            sw.WriteLine(tramite.Etiqueta);
            sw.WriteLine(tramite.Contenido);
            sw.WriteLine(tramite.FechaCreacion);
            sw.WriteLine(tramite.FechaUltModificacion);
            sw.WriteLine(tramite.UsuarioUltModificacion);
            return true;
        }
        return false;


    }


    public Tramite? BuscarUltimo(int idExpediente)
    {
        Tramite auxiliar = new Tramite();
        try
        {
            using var sr = new StreamReader(File.OpenRead(NombreArch));
            while (!sr.EndOfStream)
            {
                auxiliar.Id = int.Parse(sr.ReadLine() ?? "");
                auxiliar.ExpedienteId = int.Parse(sr.ReadLine() ?? "");
                if (auxiliar.ExpedienteId == idExpediente)
                {
                    auxiliar.Etiqueta = (EtiquetaTramite)Enum.Parse(typeof(EtiquetaTramite), sr.ReadLine() ?? "");
                    auxiliar.Contenido = sr.ReadLine() ?? "";
                    auxiliar.FechaCreacion = DateTime.Parse(sr.ReadLine() ?? "");
                    auxiliar.FechaUltModificacion = DateTime.Parse(sr.ReadLine() ?? "");
                    auxiliar.UsuarioUltModificacion = int.Parse(sr.ReadLine() ?? "");
                    Console.WriteLine("tramite encontrado");

                }
                else
                {
                    for (int i = 0; i < 5; i++)
                        sr.ReadLine();
                }

            }
            if (auxiliar.ExpedienteId == idExpediente)
                return auxiliar;
            return null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }
}
