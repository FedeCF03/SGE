namespace SGE.Repositorios;

using System.Collections.Generic;
using SGE.Aplicacion;

public class TramiteRepositorioTXT : ITramiteRepositorio
{

    readonly string _nombreArch = "tramites.txt";
    readonly string _nombreIds = "ids.txt";

    void Alta(Tramite tramite)
    {
        using var sw = new StreamWriter(_nombreArch, true);

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

    void ITramiteRepositorio.Baja(int idTramite)
    {
        throw new NotImplementedException();
    }

    Tramite ITramiteRepositorio.BuscarPorId(int idTramite)
    {
        throw new NotImplementedException();

    }
    protected int DevolverIdInc()
    {
        using var sr = new StreamReader(_nombreIds, true);
        using var sw = new StreamWriter(_nombreIds, true);
        {
            int id = int.Parse(sr.ReadLine() ?? "");
            id++;
            sw.WriteLine(id);
            return id;
        }
    }

    List<Tramite> Listar()
    {
        List<Tramite> lista = new List<Tramite>();

        using var sr = new StreamReader(File.OpenRead(_nombreArch));
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


}

List<Tramite> ListarPorEtiqueta(EtiquetaTramite etiqueta)
{
    List<Tramite> lista = new List<Tramite>();

    using var sr = new StreamReader(File.OpenRead(_nombreArch));
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
            if (auxiliar.Etiqueta == etiqueta)
                lista.Add(auxiliar);
        }
    }
    return lista;


}

void Modificar(Tramite tramite, int usuario)
{


}

public Tramite? buscarUltimo(int idExpediente)
{
    Tramite auxiliar = new Tramite();
    using var sr = new StreamReader(File.OpenRead(_nombreArch));
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
}
