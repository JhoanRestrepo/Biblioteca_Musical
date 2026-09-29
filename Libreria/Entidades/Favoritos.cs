using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Entidades
{
    public class Favoritos
    {
        public int Id { get; set; }
        public int Id_Usuario { get; set; }
        public DateTime? Fecha_Marcado { get; set; }
        public bool Activo { get; set; }

        public Usuarios? Usuario { get; set; }
        public List<Fav_Canciones>? Fav_Canciones { get; set; }
    }
}
