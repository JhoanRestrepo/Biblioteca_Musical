using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria.Entidades
{
    public class Generos
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int Popularidad { get; set; }

        [NotMapped] public List<Canciones_Generos>? Canciones_Generos { get; set; }
    }
}
