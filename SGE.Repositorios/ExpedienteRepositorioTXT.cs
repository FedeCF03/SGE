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
                sw.WriteLine(expediente.Caratula);
                sw.WriteLine(expediente.FechaCreacion);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine(idUsuario);
                sw.WriteLine(expediente.Estado);

                for (int i = 0; i < 6; i++)
                    sr.ReadLine();

                sw.Write(sr.ReadToEnd());
            }
        }

        if (id == expediente.Id)
            File.Move(NombreArchAux, NombreArch, true);
        else
        {
            File.Delete(NombreArchAux);
            throw new RepositorioException("No se encontró un expediente con ese ID o no se pudo modificar");
        }

    }
    public Expediente? BuscarPorId(int idExpediente)
    {
        Expediente? auxiliar = null;
        using var sr = new StreamReader(File.OpenRead(NombreArch));
        int n = -1;
        while (!sr.EndOfStream && (n = int.Parse(sr.ReadLine() ?? "")) != idExpediente)
        {
            for (int i = 0; i < 5; i++)
                sr.ReadLine();
        }
        if (n == idExpediente)
        {
            auxiliar = new()
            {
                Id = n,
                Caratula = sr.ReadLine() ?? "",
                FechaCreacion = DateTime.Parse(sr.ReadLine() ?? ""),
                FechaUltModificacion = DateTime.Parse(sr.ReadLine() ?? ""),
                UsuarioUltModificacion = int.Parse(sr.ReadLine() ?? "-1"),
                Estado = (EstadoExpediente)Enum.Parse(typeof(EstadoExpediente), sr.ReadLine() ?? "")
            };
        }
        return auxiliar;
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
            throw new RepositorioException("No hay un expediente asociado al trámite. Por favor agregue un expediente primero");
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
