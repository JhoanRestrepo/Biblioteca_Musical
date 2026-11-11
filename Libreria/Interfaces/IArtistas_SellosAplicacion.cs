using Libreria.Entidades;

namespace Libreria.Interfaces
{
    public interface IArtistas_SellosAplicacion
    {
        Artistas_Sellos Insertar(Artistas_Sellos entidad);
        Artistas_Sellos Actualizar(Artistas_Sellos entidad);
        List<Artistas_Sellos> Consultar();
        Artistas_Sellos Borrar(Artistas_Sellos entidad);
    }
}