using Libreria.Entidades;

namespace Libreria_Front.Interfaces
{
    public interface ICancionesPresentacion
    {
        Canciones Insertar(Canciones entidad);
        Canciones Actualizar(Canciones entidad);
        List<Canciones> Consultar();
        List<Canciones> Buscar(Canciones entidad);
        Canciones Borrar(Canciones entidad);
    }
}