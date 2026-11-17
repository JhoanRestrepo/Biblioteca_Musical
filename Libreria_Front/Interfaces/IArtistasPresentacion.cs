using Libreria.Entidades;

namespace Libreria_Front.Interfaces
{
    public interface IArtistasPresentacion
    {
        Artistas Insertar(Artistas entidad);
        Artistas Actualizar(Artistas entidad);
        List<Artistas> Consultar();
        List<Artistas> Buscar(Artistas entidad);
        Artistas Borrar(Artistas entidad);
    }
}