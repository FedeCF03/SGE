
namespace SGE.Repositorios;

using System.Collections.Generic;
using SGE.Aplicacion;
public class ExpedienteRepositorioTXT : IExpedienteRepositorio
{
    readonly string NombreIds = "idExpedientes.txt";
    readonly string NombreArch = "expediente.txt";
    readonly string NombreArchAux = "expedienteAux.txt";


    public ExpedienteRepositorioTXT()
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

    public void Alta(Expediente expediente)
    {
        using var sw = new StreamWriter(NombreArch, true);
        expediente.Id = DevolverIdInc();
        sw.WriteLine(expediente.Id);
        sw.WriteLine(expediente.Caratula);
        sw.WriteLine(expediente.FechaCreacion);
        sw.WriteLine(expediente.FechaUltModificacion);
        sw.WriteLine(expediente.UsuarioUltModificacion);
        sw.WriteLine(expediente.Estado);

    }

    public void Baja(int idExpediente)
    {
        int id = -1;
        {
            using StreamWriter sw = new(NombreArchAux);
            using StreamReader sr = new(NombreArch);
            while (!sr.EndOfStream && (id = int.Parse(sr.ReadLine() ?? "")) != idExpediente)
            {
                sw.WriteLine(id);
                sw.WriteLine(sr.ReadLine() ?? "");
                sw.WriteLine(sr.ReadLine() ?? "");
                sw.WriteLine(sr.ReadLine() ?? "");
                sw.WriteLine(sr.ReadLine() ?? "");
                sw.WriteLine(sr.ReadLine() ?? "");

            }
            if (id == idExpediente)
            {
                sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();
                sw.Write(sr.ReadToEnd());
            }
        }

        if (id == idExpediente)
        {
            File.Move(NombreArchAux, NombreArch, true);
        }
        else
        {
            File.Delete(NombreArchAux);
            throw new RepositorioException("No se encontro el expediente");
        }
    }


    public void Modificacion(int idUsuario, Expediente expediente)
    {
        int id = -1;
        {
            using StreamWriter sw = new(NombreArchAux);
            using StreamReader sr = new(NombreArch);

            while (!sr.EndOfStream && (id = int.Parse(sr.ReadLine() ?? "")) != expediente.Id)
            {
                sw.WriteLine(id);
                sw.WriteLine(sr.ReadLine() ?? "");
                sw.WriteLine(sr.ReadLine() ?? "");
                sw.WriteLine(sr.ReadLine() ?? "");
                sw.WriteLine(sr.ReadLine() ?? "");
                sw.WriteLine(sr.ReadLine() ?? "");
            }
            if (id == expediente.Id)
            {
                sw.WriteLine(id);
                sr.ReadLine();
                sw.WriteLine(expediente.Caratula);

                sw.WriteLine(DateTime.Parse(sr.ReadLine() ?? ""));

                sr.ReadLine();
                sw.WriteLine(expediente.FechaUltModificacion);
                sr.ReadLine();
                sw.WriteLine(idUsuario);
                sw.WriteLine((EstadoExpediente)Enum.Parse(typeof(EstadoExpediente), sr.ReadLine() ?? ""));

                sw.Write(sr.ReadToEnd());
            }
        }

        if (id == expediente.Id)
            File.Move(NombreArchAux, NombreArch, true);
        else
        {
            File.Delete(NombreArchAux);
            throw new RepositorioException("No se encontro un expediente con ese ID o no se pudo modificar");
        }

    }
    public Expediente BuscarPorId(int idExpediente)
    {
        using var sr = new StreamReader(File.OpenRead(NombreArch));
        int n = -1;
        while (!sr.EndOfStream && (n = int.Parse(sr.ReadLine() ?? "")) != idExpediente)
        {
            for (int i = 0; i < 5; i++)
                sr.ReadLine();
        }
        if (n != idExpediente)
            throw new RepositorioException("No se encontro un expediente con ese ID");
        else
        {
            Expediente auxiliar = new()
            {
                Id = n,
                Caratula = sr.ReadLine() ?? "",
                FechaCreacion = DateTime.Parse(sr.ReadLine() ?? ""),
                FechaUltModificacion = DateTime.Parse(sr.ReadLine() ?? ""),
                UsuarioUltModificacion = int.Parse(sr.ReadLine() ?? "-1"),
                Estado = (EstadoExpediente)Enum.Parse(typeof(EstadoExpediente), sr.ReadLine() ?? "")
            };
            return auxiliar;
        }
    }


    public List<Expediente> ListarTodos()
    {
        List<Expediente> listaRetornar = [];
        using var sr = new StreamReader(NombreArch);
        while (!sr.EndOfStream)
        {
            Expediente auxiliar = new()
            {
                Id = int.Parse(sr.ReadLine() ?? "-1"),
                Caratula = sr.ReadLine() ?? "",
                FechaCreacion = DateTime.Parse(sr.ReadLine() ?? ""),
                FechaUltModificacion = DateTime.Parse(sr.ReadLine() ?? ""),
                UsuarioUltModificacion = int.Parse(sr.ReadLine() ?? "-1"),
                Estado = (EstadoExpediente)Enum.Parse(typeof(EstadoExpediente), sr.ReadLine() ?? "")
            };
            listaRetornar.Add(auxiliar);
        }
        return listaRetornar;

    }
    // esta bien que devuelva una lista vacia si no encuentra nada?
    public List<Expediente> ListarPorEstado(EstadoExpediente estadoExpediente)
    {
        List<Expediente> listaRetornar = [];
        using var sr = new StreamReader(File.OpenRead(NombreArch));
        while (!sr.EndOfStream)
        {
            Expediente auxiliar = new()
            {
                Id = int.Parse(sr.ReadLine() ?? "-1"),
                Caratula = sr.ReadLine() ?? "",
                FechaCreacion = DateTime.Parse(sr.ReadLine() ?? ""),
                FechaUltModificacion = DateTime.Parse(sr.ReadLine() ?? ""),
                UsuarioUltModificacion = int.Parse(sr.ReadLine() ?? "-1"),
                Estado = (EstadoExpediente)Enum.Parse(typeof(EstadoExpediente), sr.ReadLine() ?? "")
            };
            if (auxiliar.Estado == estadoExpediente)
                listaRetornar.Add(auxiliar);
        };
        return listaRetornar;
    }



    public void ActualizarEstado(int idUsuario, int idExpediente, EstadoExpediente? estado)
    {
        int id = -1;
        {
            using StreamWriter sw = new(NombreArchAux);
            using StreamReader sr = new(NombreArch);
            while (!sr.EndOfStream && (id = int.Parse(sr.ReadLine() ?? "-1")) != idExpediente)
            {
                sw.WriteLine(id);
                sw.WriteLine(sr.ReadLine() ?? "");
                sw.WriteLine(sr.ReadLine() ?? "");
                sw.WriteLine(sr.ReadLine() ?? "");
                sw.WriteLine(sr.ReadLine() ?? "");
                sw.WriteLine(sr.ReadLine() ?? "");
            }
            if (id == idExpediente)
            {
                sw.WriteLine(id);
                sw.WriteLine(sr.ReadLine() ?? "");
                sw.WriteLine(sr.ReadLine() ?? "");
                sw.WriteLine(DateTime.Now);
                sw.WriteLine(idUsuario);
                sw.WriteLine(estado);
                for (int i = 0; i < 3; i++)
                    sr.ReadLine();
                sw.Write(sr.ReadToEnd());
            }
        }

        if (id == idExpediente)
            File.Move(NombreArchAux, NombreArch, true);
        else
        {
            File.Delete(NombreArchAux);
            throw new RepositorioException("No hay un expediente asociado al tramite. Por favor agregue un expediente primero");
        }
    }

    private int DevolverIdInc()
    {
        int id;
        using (var sr = new StreamReader(NombreIds))
        {
            id = int.Parse(sr.ReadLine() ?? "");
        }

        using (var sw = new StreamWriter(NombreIds))
        {
            sw.WriteLine(id + 1);
        }

        return id;
    }
}
