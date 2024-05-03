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
            sw.WriteLine(0);
        }
    }

    public void Alta(Expediente expediente)
    {
        using var sw = new StreamWriter(_nombreArch, true);
        sw.WriteLine(expediente.Id);
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
        List<Expediente> listaRetornar = new List<Expediente>();
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
        List<Expediente> listaRetornar = new List<Expediente>();
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
        using var sr = new StreamReader(_nombreIds, true);
        sr.ReadLine();
        using var sw = new StreamWriter(_nombreIds, true);
        sw.BaseStream.Seek(0, SeekOrigin.End);
        {
            int id = int.Parse(sr.ReadLine() ?? "");
            id++;
            sw.WriteLine(id);
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


        }
        if (n != expediente.Id)
            return false;

        pos = sr.BaseStream.Position;
        sr.Close();

        using StreamWriter sw = new StreamWriter(_nombreArch);
        {
            Console.WriteLine(n + " " + expediente.Id);
            Console.WriteLine("Expediente encontrado");
            Console.WriteLine("Posicion: " + pos);
            sw.BaseStream.Seek(pos, SeekOrigin.Begin);
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
            using StreamReader sr = new StreamReader("fuente.txt");
            using StreamWriter sw = new StreamWriter("fuente.txt");
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

