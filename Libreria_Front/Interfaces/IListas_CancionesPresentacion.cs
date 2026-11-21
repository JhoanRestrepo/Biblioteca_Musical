using Libreria.Entidades;

namespace Libreria_Front.Interfaces
{
    public interface IListas_CancionesPresentacion
    {
        Listas_Canciones Insertar(Listas_Canciones entidad);
        Listas_Canciones Actualizar(Listas_Canciones entidad);
        List<Listas_Canciones> Consultar();
        List<Listas_Canciones> Buscar(Listas_Canciones entidad);
        Listas_Canciones Borrar(Listas_Canciones entidad);
    }
}