using Libreria.Entidades;

namespace Libreria.Interfaces
{
    public interface IAlbumes_ArtistasAplicacion
    {
        Albumes_Artistas Insertar(Albumes_Artistas entidad);
        Albumes_Artistas Actualizar(Albumes_Artistas entidad);
        List<Albumes_Artistas> Consultar();
        Albumes_Artistas Borrar(Albumes_Artistas entidad);
    }
}