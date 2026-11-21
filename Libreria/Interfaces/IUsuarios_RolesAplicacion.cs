using Libreria.Entidades;
using Libreria.Implementaciones;

namespace Libreria.Interfaces
{
    public interface IUsuarios_RolesAplicacion
    {
        Usuarios_Roles Insertar(Usuarios_Roles entidad);
        Usuarios_Roles Actualizar(Usuarios_Roles entidad);
        List<Usuarios_Roles> Consultar();
        List<Usuarios_Roles> Buscar(Usuarios_Roles entidad);
        Usuarios_Roles Borrar(Usuarios_Roles entidad);
        
    }
}