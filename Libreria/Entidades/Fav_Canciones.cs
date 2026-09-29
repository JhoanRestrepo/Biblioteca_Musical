using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Entidades
{
     public class Fav_Canciones
    {
        public int Id { get; set; }
        public int Id_Favorito { get; set; }
        public int Id_Cancion { get; set; }

        public Favoritos? Favorito { get; set; }
        public Canciones? Cancion { get; set; }
    }
}
