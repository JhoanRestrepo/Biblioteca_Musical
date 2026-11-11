using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria.Entidades
{
    public class Artistas
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Nacionalidad { get; set; }
        public DateTime? Fecha_Inicio { get; set; }
        public string? Biografia { get; set; }

        [NotMapped] public List<Artistas_Sellos>? Artistas_Sellos { get; set; }
        [NotMapped] public List<Albumes_Artistas>? Albumes_Artistas { get; set; }
    }
}