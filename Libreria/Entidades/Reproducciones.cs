using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria.Entidades
{
    public class Reproducciones
    {
        public int Id { get; set; }
        public int Usuario { get; set; }
        public int Cancion { get; set; }
        public DateTime? Fecha_Hora { get; set; }
        public TimeSpan? Duracion { get; set; }

        [ForeignKey("Usuario")] public Usuarios? _Usuario { get; set; }
        [ForeignKey("Cancion")] public Canciones? _Cancion { get; set; }
    }
}
