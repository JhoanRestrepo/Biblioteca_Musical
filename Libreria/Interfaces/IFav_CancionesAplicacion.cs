using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Interfaces
{
    public interface IFav_CancionesAplicacion
    {
        Fav_Canciones Insertar(Fav_Canciones entidad);
        Fav_Canciones Actualizar(Fav_Canciones entidad);
        List<Fav_Canciones> Consultar();
        List<Fav_Canciones> Buscar(Fav_Canciones entidad);
        Fav_Canciones Borrar(Fav_Canciones entidad);
    }
}
