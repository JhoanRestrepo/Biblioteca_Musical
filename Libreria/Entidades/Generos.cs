using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Entidades
{
    public class Generos
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int popularidad { get; set; }

        public List<Canciones_Generos>? Canciones_Generos { get; set; }
    }
}
