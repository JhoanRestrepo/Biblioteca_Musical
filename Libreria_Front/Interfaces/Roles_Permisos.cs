using Libreria.Entidades;

namespace Libreria_Front.Interfaces
{
    public interface IRoles_PermisosPresentacion
    {
        Roles_Permisos Insertar(Roles_Permisos entidad);
        Roles_Permisos Actualizar(Roles_Permisos entidad);
        List<Roles_Permisos> Consultar();
        List<Roles_Permisos> Buscar(Roles_Permisos entidad);
        Roles_Permisos Borrar(Roles_Permisos entidad);
    }
}