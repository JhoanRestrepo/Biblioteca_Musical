using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Interfaces
{
    public interface ICanciones_IdiomasAplicacion
    {
        Canciones_Idiomas Insertar(Canciones_Idiomas entidad);
        Canciones_Idiomas Actualizar(Canciones_Idiomas entidad);
        List<Canciones_Idiomas> Consultar();
        List<Canciones_Idiomas> Buscar(Canciones_Idiomas entidad);
        Canciones_Idiomas Borrar(Canciones_Idiomas entidad);
    }
}
