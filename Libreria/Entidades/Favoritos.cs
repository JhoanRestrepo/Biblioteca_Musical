using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria.Entidades
{
    public class Favoritos
    {
        public int Id { get; set; }
        public int Usuario { get; set; }
        public DateTime? Fecha_Marcado { get; set; }
        public bool Activo { get; set; }

        [ForeignKey("Usuario")] public Usuarios? _Usuario { get; set; }

        public List<Fav_Canciones>? Fav_Canciones { get; set; }
    }
}
