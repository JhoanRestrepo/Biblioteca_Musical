using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Interfaces
{
    public interface ICancionesAplicacion
    {
        Canciones Insertar(Canciones entidad);
        Canciones Actualizar(Canciones entidad);
        List<Canciones> Consultar();
        List<Canciones> Buscar(Canciones entidad);
        Canciones Borrar(Canciones entidad);
    }
}
