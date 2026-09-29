using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Entidades
{
    public class Reproducciones
    {
        public int Id { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Cancion { get; set; }
        public DateTime? Fecha_Hora { get; set; }
        public TimeSpan? Duracion { get; set; }

        public Usuarios? Usuario { get; set; }
        public Canciones? Cancion { get; set; }
    }
}
