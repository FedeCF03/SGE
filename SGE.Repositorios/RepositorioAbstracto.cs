public abstract class RepositorioAbstracto
{
    protected string NombreIds { get; }
    protected string NombreArch { get; }

    /*
        public RepositorioText() : base("Ids.txt", "Archivo.txt")
        {
        }

    */
    public RepositorioAbstracto(string nombreIds, string nombreArch)
    {
        NombreIds = nombreIds;
        NombreArch = nombreArch;

        try
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
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    protected int DevolverIdInc()
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




}