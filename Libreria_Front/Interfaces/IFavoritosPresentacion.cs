using Libreria.Entidades;

namespace Libreria_Front.Interfaces
{
    public interface IFavoritosPresentacion
    {
        Favoritos Insertar(Favoritos entidad);
        Favoritos Actualizar(Favoritos entidad);
        List<Favoritos> Consultar();
        List<Favoritos> Buscar(Favoritos entidad);
        Favoritos Borrar(Favoritos entidad);
    }
}