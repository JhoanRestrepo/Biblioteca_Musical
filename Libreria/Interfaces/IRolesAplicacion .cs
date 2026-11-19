using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Interfaces
{
    public interface IRolesAplicacion
    {
        Roles Insertar(Roles entidad);
        Roles Actualizar(Roles entidad);
        List<Roles> Consultar();
        List<Roles> Buscar(Roles entidad);
        Roles Borrar(Roles entidad);
    }
}
