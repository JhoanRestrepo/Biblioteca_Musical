using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Interfaces
{
    public interface ICanciones_CompositoresAplicacion
    {
        Canciones_Compositores Insertar(Canciones_Compositores entidad);
        Canciones_Compositores Actualizar(Canciones_Compositores entidad);
        List<Canciones_Compositores> Consultar();
        List<Canciones_Compositores> Buscar(Canciones_Compositores entidad);
        Canciones_Compositores Borrar(Canciones_Compositores entidad);
    }
}
