using Libreria.Entidades;

namespace Libreria_Front.Interfaces
{
    public interface IFav_CancionesPresentacion
    {
        Fav_Canciones Insertar(Fav_Canciones entidad);
        Fav_Canciones Actualizar(Fav_Canciones entidad);
        List<Fav_Canciones> Consultar();
        List<Fav_Canciones> Buscar(Fav_Canciones entidad);
        Fav_Canciones Borrar(Fav_Canciones entidad);
    }
}