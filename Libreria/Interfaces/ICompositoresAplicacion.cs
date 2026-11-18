using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Interfaces
{
    public interface ICompositoresAplicacion
    {
        Compositores Insertar(Compositores entidad);
        Compositores Actualizar(Compositores entidad);
        List<Compositores> Consultar();
        List<Compositores> Buscar(Compositores entidad);
        Compositores Borrar(Compositores entidad);
    }
}
