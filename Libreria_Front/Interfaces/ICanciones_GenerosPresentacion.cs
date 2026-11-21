using Libreria.Entidades;

namespace Libreria_Front.Interfaces
{
    public interface ICanciones_GenerosPresentacion
    {
        Canciones_Generos Insertar(Canciones_Generos entidad);
        Canciones_Generos Actualizar(Canciones_Generos entidad);
        List<Canciones_Generos> Consultar();
        List<Canciones_Generos> Buscar(Canciones_Generos entidad);
        Canciones_Generos Borrar(Canciones_Generos entidad);
    }
}