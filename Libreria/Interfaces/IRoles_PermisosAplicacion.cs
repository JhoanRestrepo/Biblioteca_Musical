using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Interfaces
{
    public interface IRoles_PermisosAplicacion
    {
        Roles_Permisos Insertar(Roles_Permisos entidad);
        Roles_Permisos Actualizar(Roles_Permisos entidad);
        List<Roles_Permisos> Consultar();
        List<Roles_Permisos> Buscar(Roles_Permisos entidad);
        Roles_Permisos Borrar(Roles_Permisos entidad);
    }
}
