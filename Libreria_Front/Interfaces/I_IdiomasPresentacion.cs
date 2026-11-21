using Libreria.Entidades;

namespace Libreria_Front.Interfaces
{
    public interface I_IdiomasPresentacion
    {
        Idiomas Insertar(Idiomas entidad);
        Idiomas Actualizar(Idiomas entidad);
        List<Idiomas> Consultar();
        List<Idiomas> Buscar(Idiomas entidad);
        Idiomas Borrar(Idiomas entidad);
    }
}