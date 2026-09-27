using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Entidades
{
    public class Albumes
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public DateTime? Fecha_Lanzamiento { get; set; }
        public string? Portada { get; set; }

        public List<Albumes_Artistas>? Albumes_Artistas { get; set; }
        public List<Canciones>? Canciones { get; set; }
    }
}
