using Libreria.Entidades;

namespace Libreria_Front.Interfaces
{
    public interface ISuscripcionesPresentacion
    {
        Suscripciones Insertar(Suscripciones entidad);
        Suscripciones Actualizar(Suscripciones entidad);
        List<Suscripciones> Consultar();
        List<Suscripciones> Buscar(Suscripciones entidad);
        Suscripciones Borrar(Suscripciones entidad);
    }
}