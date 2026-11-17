using Libreria.Entidades;
using Libreria.Implementaciones;

namespace Libreria.Interfaces
{
    public interface IAlbumesAplicacion
    {
        Albumes Insertar(Albumes entidad);
        Albumes Actualizar(Albumes entidad);
        List<Albumes> Consultar();
        List<Albumes> Buscar(Albumes entidad);
        Albumes Borrar(Albumes entidad);
        List<Albumes_Artistas> Buscar(AlbumesAplicacion album);
    }
}