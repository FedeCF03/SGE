namespace SGE.Repositorios;

using System.Collections.Generic;
using System.Data;
using SGE.Aplicacion;

public class TramiteRepositorioTXT : ITramiteRepositorio
{
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

    //El metodo devuelve un booleano, el ID del expediente al que el trámite está asignado, o -1 si no existe dicho trámite
    public void Baja(int idTramite, out int idExpediente)
    {
        int id = -1;
        idExpediente = -1;
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
            File.Move(NombreArchAux, NombreArch, true);
        }
        else
        {
            throw new Exception("No se encontró el trámite");
        }
    }
    public void BorrarTodosDeIdExpediente(int expedienteId)
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
    }


    public Tramite BuscarPorId(int idTramite)
    {

        int n = -1;
        using StreamReader sr = new(NombreArch);
        while (!sr.EndOfStream && ((n = int.Parse(sr.ReadLine() ?? "-1")) != idTramite))
        {
            for (int i = 0; i < 6; i++)
                sr.ReadLine();
        }
        if (n != idTramite)
            throw new RepositorioException("No se encontró un trámite con ese ID");
        else
        {
            Tramite auxiliar = new()
            {
                Id = n,
                ExpedienteId = int.Parse(sr.ReadLine() ?? ""),
                Etiqueta = (EtiquetaTramite)Enum.Parse(typeof(EtiquetaTramite), sr.ReadLine() ?? ""),
                Contenido = sr.ReadLine(),
                FechaCreacion = DateTime.Parse(sr.ReadLine() ?? ""),
                FechaUltModificacion = DateTime.Parse(sr.ReadLine() ?? ""),
                UsuarioUltModificacion = int.Parse(sr.ReadLine() ?? "")
            };
            return auxiliar;
        }
    }
    private int DevolverIdInc()
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


    public List<Tramite> ListarTodos()
    {
        List<Tramite> lista = [];

        using var sr = new StreamReader(File.OpenRead(NombreArch));

        while (!sr.EndOfStream)
        {
            Tramite auxiliar = new()
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


    public List<Tramite> ListarPorEtiqueta(EtiquetaTramite etiqueta)
    {
        List<Tramite> lista = [];
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
            if (auxiliar.Etiqueta.Equals(etiqueta))
                lista.Add(auxiliar);
        }
        return lista;
    }

    public List<Tramite> ListarTodosDeIdExpediente(int expedienteId)
    {
        List<Tramite> lista = [];
        Tramite auxiliar;
        using var sr = new StreamReader(NombreArch);
        while (!sr.EndOfStream)
        {
            auxiliar = new()
            {
                Id = int.Parse(sr.ReadLine() ?? ""),
                ExpedienteId = int.Parse(sr.ReadLine() ?? ""),
                Etiqueta = (EtiquetaTramite)Enum.Parse(typeof(EtiquetaTramite), sr.ReadLine() ?? ""),
                Contenido = sr.ReadLine(),
                FechaCreacion = DateTime.Parse(sr.ReadLine() ?? ""),
                FechaUltModificacion = DateTime.Parse(sr.ReadLine() ?? ""),
                UsuarioUltModificacion = int.Parse(sr.ReadLine() ?? "")
            };
            if (auxiliar.ExpedienteId == expedienteId)
                lista.Add(auxiliar);
        }
        return lista;
    }


    //Modifica el trámite en el archivo de texto y devuelve la etiqueta del trámite antes de ser modificado
    public void Modificar(Tramite tramite)
    {
        int id = -1;
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
                sr.ReadLine();
                sw.WriteLine(tramite.ExpedienteId);

                sr.ReadLine();
                sw.WriteLine(tramite.Etiqueta);

                sr.ReadLine();
                sw.WriteLine(tramite.Contenido);

                sw.WriteLine(DateTime.Parse(sr.ReadLine() ?? ""));

                sr.ReadLine();
                sw.WriteLine(tramite.FechaUltModificacion);

                sr.ReadLine();
                sw.WriteLine(tramite.UsuarioUltModificacion);

                sw.Write(sr.ReadToEnd());
            }
        }

        if (id == tramite.Id)
            File.Move(NombreArchAux, NombreArch, true);
        else
        {
            File.Delete(NombreArchAux);
            throw new RepositorioException("No se encontró un trámite con ese ID");
        }

    }


    public Tramite? BuscarUltimo(int idExpediente)
    {
        Tramite resultado = new() { Id = -1 };
        Tramite auxiliar = new();

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


}
