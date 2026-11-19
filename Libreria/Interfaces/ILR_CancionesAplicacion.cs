using Libreria.Entidades;
using Libreria.Implementaciones;

namespace Libreria.Interfaces
{
    public interface ILR_CancionesAplicacion
    {
        LR_Canciones Insertar(LR_Canciones entidad);
        LR_Canciones Actualizar(LR_Canciones entidad);
        List<LR_Canciones> Consultar();
        List<LR_Canciones> Buscar(LR_Canciones entidad);
        LR_Canciones Borrar(LR_Canciones entidad);
        
    }
}