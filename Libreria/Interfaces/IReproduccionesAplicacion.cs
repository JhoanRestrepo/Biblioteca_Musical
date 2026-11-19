using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Interfaces
{
    public interface IReproduccionesAplicacion
    {
        Reproducciones Insertar(Reproducciones entidad);
        Reproducciones Actualizar(Reproducciones entidad);
        List<Reproducciones> Consultar();
        List<Reproducciones> Buscar(Reproducciones entidad);
        Reproducciones Borrar(Reproducciones entidad);
    }
}
