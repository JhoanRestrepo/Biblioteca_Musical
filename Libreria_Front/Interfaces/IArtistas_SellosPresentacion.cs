using Libreria.Entidades;

namespace Libreria_Front.Interfaces
{
    public interface IArtistas_SellosPresentacion
    {
        Artistas_Sellos Insertar(Artistas_Sellos entidad);
        Artistas_Sellos Actualizar(Artistas_Sellos entidad);
        List<Artistas_Sellos> Consultar();
        List<Artistas_Sellos> Buscar(Artistas_Sellos entidad);
        Artistas_Sellos Borrar(Artistas_Sellos entidad);
    }
}