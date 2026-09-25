using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Entidades
{
    internal class Sellos_Discograficos
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Pais { get; set; }
        public DateTime? Fecha_Fundacion { get; set; }
        public string? Sitio_Web { get; set; }

        public List<Artistas_Sellos>? Artistas_Sellos { get; set; }
    }
}
