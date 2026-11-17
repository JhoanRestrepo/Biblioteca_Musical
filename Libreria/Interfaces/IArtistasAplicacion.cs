using Libreria.Entidades;
using Libreria.Implementaciones;

namespace Libreria.Interfaces
{
    public interface IArtistasAplicacion
    {
        Artistas Insertar(Artistas entidad);
        Artistas Actualizar(Artistas entidad);
        List<Artistas> Consultar();
        List<Artistas> Buscar(Artistas entidad);
        Artistas Borrar(Artistas entidad);
        List<Albumes_Artistas> Buscar(ArtistasAplicacion artista);
    }
}