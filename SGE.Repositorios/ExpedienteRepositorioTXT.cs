/* Copyrigth © 2025 - Grupo 2
 * 
 * Licencia: 
 * 
 * Se concede permiso, de forma gratuita, a cualquier persona que obtenga una copia de este software y de los archivos de documentación asociados (el "Software"), para utilizar el Software sin restricción, incluyendo sin limitación los derechos para usar, copiar, modificar, fusionar, publicar, distribuir, sublicenciar, y/o vender copias del Software, y para permitir a las personas a las que se les proporcione el Software a hacer lo mismo, con sujeción a las siguientes condiciones:
 * 
 * El aviso de copyright y la siguiente licencia serán incluidos en todas las copias o partes sustanciales del Software.
 * 
 * EL SOFTWARE SE ENTREGA "TAL CUAL", SIN GARANTÍA DE NINGÚN TIPO, EXPRESA O IMPLÍCITA, INCLUYENDO PERO NO LIMITADO A GARANTÍAS DE COMERCIALIZACIÓN, IDONEIDAD PARA UN PROPÓSITO PARTICULAR Y NO INFRACCIÓN. EN NINGÚN CASO LOS AUTORES O PROPIETARIOS DE LOS DERECHOS DE AUTOR SERÁN RESPONSABLES DE NINGUNA RECLAMACIÓN, DAÑOS U OTRAS RESPONSABILIDADES, YA SEA EN UNA ACCIÓN DE CONTRATO, AGRAVIO O CUALQUIER OTRO MOTIVO, DERIVADAS DE, FUERA O EN CONEXIÓN CON EL SOFTWARE O EL USO U OTRO TIPO DE ACCIONES EN EL SOFTWARE.
 * 
 * 
 * 

*/


namespace SGE.Repositorios;

using System.Collections.Generic;
using SGE.Aplicacion;
public class ExpedienteRepositorioTXT : IExpedienteRepositorio
{
    readonly string NombreIds = "idExpedientes.txt";

    readonly string NombreArch = "expediente.txt";


    public ExpedienteRepositorioTXT()
    {
        if (!File.Exists(NombreArch))
        {
            File.Create(NombreArch);
        }
        if (!File.Exists(NombreIds))
        {
            using var sw = new StreamWriter(NombreIds);
            sw.WriteLine(1);
        }
    }

    public void Alta(Expediente expediente)
    {
        try
        {
            using var sw = new StreamWriter(NombreArch, true);
            expediente.Id = DevolverIdInc();
            //cheackear si tiene -1 o que hacer?
            sw.WriteLine(expediente.Id);
            sw.WriteLine(expediente.Caratula);
            sw.WriteLine(expediente.FechaCreacion);
            sw.WriteLine(expediente.FechaUltModificacion);
            sw.WriteLine(expediente.UsuarioUltModificacion);
            sw.WriteLine(expediente.Estado);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public bool Baja(int idExpediente)
    {
        try
        {
            string NombreArchAux = "auxiliar.txt";
            File.Create(NombreArchAux);
            using StreamWriter sw = new(NombreArchAux);
            using StreamReader sr = new(File.OpenRead(NombreArch));

            int id = -1;
            while (!sr.EndOfStream && (id = int.Parse(sr.ReadLine() ?? "")) != idExpediente)
            {
                if (id != idExpediente)
                {
                    sw.WriteLine(id);
                    sw.WriteLine(sr.ReadLine() ?? "");
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
            sw.Close();
            sr.Close();
            if (id == idExpediente)
                File.Move(NombreArchAux, NombreArch, true);
            return id == idExpediente;
        }
        catch (Exception e)
        {

            Console.WriteLine(e.Message);
            return false;
        }
    }

    public Expediente? BuscarPorId(int idExpediente)
    {
        try
        {
            using var sr = new StreamReader(File.OpenRead(NombreArch));
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
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }

    public List<Expediente>? ListarTodos()
    {
        List<Expediente> listaRetornar = [];
        try
        {
            using var sr = new StreamReader(NombreArch);
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
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }

    }
    // esta bien que devuelva una lista vacia si no encuentra nada?
    public List<Expediente> ListarPorEstado(EstadoExpediente estadoExpediente)
    {
        List<Expediente> listaRetornar = [];
        try
        {
            using var sr = new StreamReader(File.OpenRead(NombreArch));
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
            return listaRetornar;

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return listaRetornar;
        }
    }
    public int DevolverIdInc()
    {
        int id;
        try
        {
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
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return -1;
        }
    }
    public bool Modificacion(int idUsuario, Expediente expediente)
    {
        //hay que pasar todo el expediente o solo los campos el estado?
        //suponemos que esta entero 7u7

        long pos = -1;
        int n = -1;
        using var sr = new StreamReader(File.OpenRead(NombreArch));
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

        using StreamWriter sw = new(NombreArch, true);
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
    public void ActualizarEstado(int idUsuario, int idExpediente, EstadoExpediente estado)
    {
        try
        {
            int n = -1;
            long pos = 0;
            using (StreamReader sr = new(NombreArch))
            {
                while (!sr.EndOfStream && (n = int.Parse(sr.ReadLine() ?? "")) != idExpediente)
                {
                    for (int i = 0; i < 5; i++)
                        sr.ReadLine();
                }

                if (n == idExpediente)
                {
                    sr.ReadLine();
                    sr.ReadLine();
                    pos = sr.BaseStream.Position;
                    sr.Close();
                }
                Console.WriteLine("expediente encontrado");

            }
            if (n == idExpediente)
            {
                using StreamWriter sw = new(NombreArch);
                sw.BaseStream.Seek(pos, SeekOrigin.Begin);
                sw.WriteLine(DateTime.Now.ToString());
                sw.WriteLine(idUsuario);
                sw.WriteLine(estado);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}


// Path: SGE.Repositorios/UsuarioRepositorioTXT.cs