using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Front.Interfaces
{
    public interface IListas_ReproduccionesPresentacion
    {
        Listas_Reproducciones Insertar(Listas_Reproducciones entidad);
        Listas_Reproducciones Actualizar(Listas_Reproducciones entidad);
        List<Listas_Reproducciones> Consultar();
        List<Listas_Reproducciones> Buscar(Listas_Reproducciones entidad);
        Listas_Reproducciones Borrar(Listas_Reproducciones entidad);
    }
}
