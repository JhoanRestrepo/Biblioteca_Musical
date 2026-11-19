using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Interfaces
{
    public interface ISuscripcionesAplicacion
    {
        Suscripciones Insertar(Suscripciones entidad);
        Suscripciones Actualizar(Suscripciones entidad);
        List<Suscripciones> Consultar();
        List<Suscripciones> Buscar(Suscripciones entidad);
        Suscripciones Borrar(Suscripciones entidad);
    }
}
