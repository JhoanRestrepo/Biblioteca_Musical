using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Interfaces
{
    public interface IListas_CancionesAplicacion
    {
        Listas_Canciones Insertar(Listas_Canciones entidad);
        Listas_Canciones Actualizar(Listas_Canciones entidad);
        List<Listas_Canciones> Consultar();
        List<Listas_Canciones> Buscar(Listas_Canciones entidad);
        Listas_Canciones Borrar(Listas_Canciones entidad);
    }
}
