using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria.Entidades
{
     public class Fav_Canciones
    {
        public int Id { get; set; }
        public int Favorito { get; set; }
        public int Cancion { get; set; }

        [ForeignKey("Favorito")] public Favoritos? _Favorito { get; set; }
        [ForeignKey("Cancion")] public Canciones? _Cancion { get; set; }
    }
}
