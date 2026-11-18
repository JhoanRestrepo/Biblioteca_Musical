using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Interfaces
{
    public interface ICanciones_GenerosAplicacion
    {
        Canciones_Generos Insertar(Canciones_Generos entidad);
        Canciones_Generos Actualizar(Canciones_Generos entidad);
        List<Canciones_Generos> Consultar();
        List<Canciones_Generos> Buscar(Canciones_Generos entidad);
        Canciones_Generos Borrar(Canciones_Generos entidad);
    }
}
