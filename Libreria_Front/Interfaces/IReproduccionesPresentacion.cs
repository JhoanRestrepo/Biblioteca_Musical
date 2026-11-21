using Libreria.Entidades;

namespace Libreria_Front.Interfaces
{
    public interface IReproduccionesPresentacion
    {
        Reproducciones Insertar(Reproducciones entidad);
        Reproducciones Actualizar(Reproducciones entidad);
        List<Reproducciones> Consultar();
        List<Reproducciones> Buscar(Reproducciones entidad);
        Reproducciones Borrar(Reproducciones entidad);
    }
}