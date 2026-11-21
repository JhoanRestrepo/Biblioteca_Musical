using Libreria.Entidades;

namespace Libreria_Front.Interfaces
{
    public interface ICanciones_CompositoresPresentacion
    {
        Canciones_Compositores Insertar(Canciones_Compositores entidad);
        Canciones_Compositores Actualizar(Canciones_Compositores entidad);
        List<Canciones_Compositores> Consultar();
        List<Canciones_Compositores> Buscar(Canciones_Compositores entidad);
        Canciones_Compositores Borrar(Canciones_Compositores entidad);
    }
}