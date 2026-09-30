using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria.Entidades
{
    public class Listas_Canciones
    {
        public int Id { get; set; }
        public int Cancion { get; set; }
        public int Posicion { get; set; }
        public DateTime Fecha_Agregada { get; set; } 
        //public int Favorita { get; set; } //bool?

        [ForeignKey("Cancion")] public Canciones? _Cancion { get; set; }
        //[ForeignKey("Favorita")] public Favoritas? _Favorita { get; set; }
    }
}
