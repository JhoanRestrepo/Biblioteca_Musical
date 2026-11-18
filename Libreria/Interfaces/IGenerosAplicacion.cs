using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Interfaces
{
    public interface IGenerosAplicacion
    {
        Generos Insertar(Generos entidad);
        Generos Actualizar(Generos entidad);
        List<Generos> Consultar();
        List<Generos> Buscar(Generos entidad);
        Generos Borrar(Generos entidad);
    }
}
