using Libreria.Entidades;

namespace Libreria_Front.Interfaces
{
    public interface ICanciones_IdiomasPresentacion
    {
        Canciones_Idiomas Insertar(Canciones_Idiomas entidad);
        Canciones_Idiomas Actualizar(Canciones_Idiomas entidad);
        List<Canciones_Idiomas> Consultar();
        List<Canciones_Idiomas> Buscar(Canciones_Idiomas entidad);
        Canciones_Idiomas Borrar(Canciones_Idiomas entidad);
    }
}