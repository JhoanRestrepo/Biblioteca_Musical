using Libreria.Entidades;

namespace Libreria_Front.Interfaces
{
    public interface IGenerosPresentacion
    {
        Generos Insertar(Generos entidad);
        Generos Actualizar(Generos entidad);
        List<Generos> Consultar();
        List<Generos> Buscar(Generos entidad);
        Generos Borrar(Generos entidad);
    }
}