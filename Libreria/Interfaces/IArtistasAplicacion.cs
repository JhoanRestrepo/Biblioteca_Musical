using Libreria.Entidades;

namespace Libreria.Interfaces
{
    public interface IArtistasAplicacion
    {
        Artistas Insertar(Artistas entidad);
        Artistas Actualizar(Artistas entidad);
        List<Artistas> Consultar();
        Artistas Borrar(Artistas entidad);
    }
}