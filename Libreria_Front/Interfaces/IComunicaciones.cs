using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Front.Interfaces
{
    public interface IComunicaciones
    {
        Task<T> Ejecutar<T>(string url, object entidad);
    }
}
