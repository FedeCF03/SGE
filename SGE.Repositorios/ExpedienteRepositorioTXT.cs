namespace SGE.Repositorios;

using System.Collections.Generic;
using SGE.Aplicacion;
public class ExpedienteRepositorioTXT : IExpedienteRepositorio
{
    readonly string _nombreIds = "ids.txt";

    readonly string _nombreArch = "expediente.txt";


    public ExpedienteRepositorioTXT()
    {
        if (!File.Exists(_nombreArch))
        {
            File.Create(_nombreArch);
        }
        if (!File.Exists(_nombreIds))
        {
            using var sw = new StreamWriter(_nombreIds);
            sw.WriteLine(1);
        }
    }

    public void Alta(Expediente expediente)
    {
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(DevolverIdInc());
        sw.WriteLine(expediente.Caratula);
        sw.WriteLine(expediente.FechaCreacion);
        sw.WriteLine(expediente.FechaUltModificacion);
        sw.WriteLine(expediente.UsuarioUltModificacion);
        sw.WriteLine(expediente.Estado);
    }

    // public bool Baja(int idExpediente)
    // {
    //     try
    //     {
    //         StreamReader sr = new StreamReader(_nombreArch);
    //         StreamWriter sw = new StreamWriter(_nombreArch);

    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e.Message);
    //     }
    // }

    public Expediente? BuscarPorId(int idExpediente)
    {
        using var sr = new StreamReader(File.OpenRead(_nombreArch));
        {
            int n = -1;
            while (!sr.EndOfStream && (n = int.Parse(sr.ReadLine() ?? "")) != idExpediente)
            {
                for (int i = 0; i < 5; i++)
                    sr.ReadLine();
            }
            if (n == idExpediente)
            {
                Expediente auxiliar = new Expediente(n, sr.ReadLine() ?? "", DateTime.Parse(sr.ReadLine() ?? ""), DateTime.Parse(sr.ReadLine() ?? ""), int.Parse(sr.ReadLine() ?? ""), (EstadoExpediente)Enum.Parse(typeof(EstadoExpediente), sr.ReadLine() ?? ""));
                return auxiliar;

            }
            else
                return null;
        }
    }

    public List<Expediente> ListarTodos()
    {
        List<Expediente> listaRetornar = [];
        using var sr = new StreamReader(_nombreArch);
        {
            while (!sr.EndOfStream)
            {
                Expediente auxiliar = new Expediente(
                    int.Parse(sr.ReadLine() ?? ""),
                    sr.ReadLine() ?? "",
                    DateTime.Parse(sr.ReadLine() ?? ""),
                    DateTime.Parse(sr.ReadLine() ?? ""),
                    int.Parse(sr.ReadLine() ?? ""),
                    (EstadoExpediente)Enum.Parse(typeof(EstadoExpediente), sr.ReadLine() ?? "")
                );

                listaRetornar.Add(auxiliar);
            }
            return listaRetornar;
        }
    }
    // esta bien que devuelva una lista vacia si no encuentra nada?
    public List<Expediente> ListarPorEstado(EstadoExpediente estadoExpediente)
    {
        List<Expediente> listaRetornar = [];
        using var sr = new StreamReader(File.OpenRead(_nombreArch));
        {
            while (!sr.EndOfStream)
            {
                Expediente auxiliar = new Expediente(
                    int.Parse(sr.ReadLine() ?? ""),
                    sr.ReadLine() ?? "",
                    DateTime.Parse(sr.ReadLine() ?? ""),
                    DateTime.Parse(sr.ReadLine() ?? ""),
                    int.Parse(sr.ReadLine() ?? ""),
                    (EstadoExpediente)Enum.Parse(typeof(EstadoExpediente), sr.ReadLine() ?? "")
                );
                if (auxiliar.Estado == estadoExpediente)
                    listaRetornar.Add(auxiliar);
            };
        }
        return listaRetornar;
    }
    public int DevolverIdInc()
    {
        var sr = new StreamReader(_nombreIds);
        int id = int.Parse(sr.ReadLine() ?? "");
        sr.Dispose();
        using var sw = new StreamWriter(_nombreIds);
        {
            sw.WriteLine(id + 1);
            return id;
        }
    }
    public bool Modificacion(int idUsuario, Expediente expediente)
    {
        //hay que pasar todo el expediente o solo los campos el estado?
        //suponemos que esta entero 7u7

        long pos = -1;
        int n = -1;
        using var sr = new StreamReader(File.OpenRead(_nombreArch));
        {
            Console.WriteLine(sr.BaseStream.Length.ToString());
            while (!sr.EndOfStream && (n = int.Parse(sr.ReadLine() ?? "")) != expediente.Id)
            {
                for (int i = 0; i < 5; i++)
                    sr.ReadLine();
            }

            // como hacer el pos ??? nos pone null
        }
        if (n != expediente.Id)
            return false;
        Console.WriteLine("Expediente encontrado");
        pos = sr.BaseStream.Position;
        sr.Close();

        using StreamWriter sw = new(_nombreArch, true);
        {
            Console.WriteLine(n + " " + expediente.Id);
            Console.WriteLine("Expediente encontrado");
            Console.WriteLine("Posicion: " + pos);

            sw.BaseStream.Position = pos;
            sw.WriteLine(expediente.Id.ToString());
            sw.WriteLine(expediente.Caratula);
            sw.WriteLine(expediente.FechaCreacion);
            sw.WriteLine(expediente.FechaUltModificacion);
            sw.WriteLine(expediente.UsuarioUltModificacion);
            sw.WriteLine(expediente.Estado);
            return true;
        }

    }
    public void ActualizarEstado(int idUsuario, int idExpediente, EstadoExpediente estado)
    {
        try
        {
            using StreamReader sr = new("fuente.txt");
            using StreamWriter sw = new("fuente.txt");
            int n = -1;
            while (!sr.EndOfStream && (n = int.Parse(sr.ReadLine() ?? "")) != idExpediente)
            {
                for (int i = 0; i < 5; i++)
                    sr.ReadLine();
            }
            if (n == idExpediente)
            {
                sr.ReadLine();
                sr.ReadLine();

                sw.BaseStream.Seek(sr.BaseStream.Position, SeekOrigin.Begin);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine(idUsuario);
                sw.WriteLine(estado);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public bool Baja(int idExpediente)
    {
        throw new NotImplementedException();
    }

}

