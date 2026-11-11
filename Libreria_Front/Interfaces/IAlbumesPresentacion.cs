using Libreria.Entidades;

namespace Libreria_Front.Interfaces
{
    public interface IAlbumesPresentacion
    {
        Albumes Insertar(Albumes entidad);
        Albumes Actualizar(Albumes entidad);
        List<Albumes> Consultar();
        List<Albumes> Buscar(Albumes entidad);
        Albumes Borrar(Albumes entidad);
    }
}