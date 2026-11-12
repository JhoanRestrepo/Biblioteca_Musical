using Libreria.Entidades;

namespace Libreria_Front.Interfaces
{
    public interface IAlbumes_ArtistasPresentacion
    {
        Albumes_Artistas Insertar(Albumes_Artistas entidad);
        Albumes_Artistas Actualizar(Albumes_Artistas entidad);
        List<Albumes_Artistas> Consultar();
        List<Albumes_Artistas> Buscar(Albumes_Artistas entidad);
        Albumes_Artistas Borrar(Albumes_Artistas entidad);
    }
}