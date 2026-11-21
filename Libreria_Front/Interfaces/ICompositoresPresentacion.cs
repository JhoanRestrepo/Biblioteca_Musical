using Libreria.Entidades;

namespace Libreria_Front.Interfaces
{
    public interface ICompositoresPresentacion
    {
        Compositores Insertar(Compositores entidad);
        Compositores Actualizar(Compositores entidad);
        List<Compositores> Consultar();
        List<Compositores> Buscar(Compositores entidad);
        Compositores Borrar(Compositores entidad);
    }
}