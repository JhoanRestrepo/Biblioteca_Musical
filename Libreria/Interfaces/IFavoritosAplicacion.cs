using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Interfaces
{
    public interface IFavoritosAplicacion
    {
        Favoritos Insertar(Favoritos entidad);
        Favoritos Actualizar(Favoritos entidad);
        List<Favoritos> Consultar();
        List<Favoritos> Buscar(Favoritos entidad);
        Favoritos Borrar(Favoritos entidad);
    }
}
