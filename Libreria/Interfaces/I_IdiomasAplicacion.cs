using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Interfaces
{
    public interface I_IdiomasAplicacion
    {
        Idiomas Insertar(Idiomas entidad);
        Idiomas Actualizar(Idiomas entidad);
        List<Idiomas> Consultar();
        List<Idiomas> Buscar(Idiomas entidad);
        Idiomas Borrar(Idiomas entidad);
    }
}
