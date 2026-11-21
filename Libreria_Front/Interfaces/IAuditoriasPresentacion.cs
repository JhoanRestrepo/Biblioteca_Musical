using Libreria.Entidades;

namespace Libreria_Front.Interfaces
{
    public interface IAuditoriasPresentacion
    {
        Auditorias Insertar(Auditorias entidad);
        Auditorias Actualizar(Auditorias entidad);
        List<Auditorias> Consultar();
        List<Auditorias> Buscar(Auditorias entidad);
        Auditorias Borrar(Auditorias entidad);
    }
}