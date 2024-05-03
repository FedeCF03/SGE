namespace SGE.Repositorios;

using System.Collections.Generic;
using SGE.Aplicacion;

public class TramiteRepositorioTXT : ITramiteRepositorio
{
    // como implementar el autoincremento de id; 
    string NombreArch { get; } = "tramites.txt";
    string NombreIds { get; } = "ids.txt";

    public void Alta(Tramite tramite)
    {
        using var sw = new StreamWriter(NombreArch, true);

        {
            sw.WriteLine(DevolverIdInc());
            sw.WriteLine(tramite.ExpedienteId);
            sw.WriteLine(tramite.Etiqueta);
            sw.WriteLine(tramite.Contenido);
            sw.WriteLine(tramite.FechaCreacion);
            sw.WriteLine(tramite.FechaUltModificacion);
            sw.WriteLine(tramite.UsuarioUltModificacion);
        }

    }

    public void Baja(int idTramite)
    {
        throw new NotImplementedException();
    }

    public Tramite? BuscarPorId(int idTramite)
    {
        Tramite auxiliar = new Tramite();
        using var sr = new StreamReader(NombreArch);
        {
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
            {
                return null;
            }
        }
    }
    protected int DevolverIdInc()
    {
        using var sr = new StreamReader(NombreIds, true);
        using var sw = new StreamWriter(NombreIds, true);
        {
            int id = int.Parse(sr.ReadLine() ?? "");
            id++;
            sw.WriteLine(id);
            return id;
        }
    }

    public List<Tramite> Listar()
    {
        List<Tramite> lista = new List<Tramite>();

        using var sr = new StreamReader(File.OpenRead(NombreArch));
        {
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
        }
        return lista;
    }


    public List<Tramite> ListarPorEtiqueta(EtiquetaTramite etiqueta)
    {
        List<Tramite> lista = new List<Tramite>();

        using var sr = new StreamReader(NombreArch);
        {
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
        }
        return lista;


    }

    public bool Modificar(Tramite tramite)
    {
        int n = 0;
        using var sr = new StreamReader(NombreArch);
        using var sw = new StreamWriter(NombreArch);
        {
            while (!sr.EndOfStream && (n = int.Parse(sr.ReadLine() ?? "")) != tramite.Id)
            {
                for (int i = 0; i < 6; i++)
                    sr.ReadLine();
            }

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
        using var sr = new StreamReader(File.OpenRead(NombreArch));
        {
            while (!sr.EndOfStream)
            {
                auxiliar.Id = int.Parse(sr.ReadLine() ?? "");
                auxiliar.ExpedienteId = int.Parse(sr.ReadLine() ?? "");
                if (auxiliar.ExpedienteId == idExpediente)
                {
                    auxiliar.Etiqueta = (EtiquetaTramite)Enum.Parse(typeof(EtiquetaTramite), sr.ReadLine() ?? "");
                    auxiliar.Contenido = sr.ReadLine();
                    auxiliar.FechaCreacion = DateTime.Parse(sr.ReadLine() ?? "");
                    auxiliar.FechaUltModificacion = DateTime.Parse(sr.ReadLine() ?? "");
                    auxiliar.UsuarioUltModificacion = int.Parse(sr.ReadLine() ?? "");
                }
                for (int i = 0; i < 5; i++)
                    sr.ReadLine();
            }
            if (auxiliar.ExpedienteId == idExpediente)
                return auxiliar;
            return null;
        }
    }
    int ITramiteRepositorio.DevolverIdInc()
    {
        throw new NotImplementedException();
    }
}
