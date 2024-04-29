namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo, ServicioAutorizacionProvisorio servicio)
{
    private readonly ITramiteRepositorio _repo = repo;
    private readonly ServicioAutorizacionProvisorio _servicio = servicio;

    public bool Ejecutar(int usuario, int idTramite)
    {

        if (_servicio.PoseeElPermiso(usuario, Permiso.TramiteBaja))
            _repo.Baja(idTramite);
        return true;
    }
}



