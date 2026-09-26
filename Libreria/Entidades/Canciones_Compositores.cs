using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria.Entidades
{
    internal class Canciones_Compositores
    {
        public int Id { get; set; }
        public int Id_Cancion { get; set; }
        public int Id_Compositor { get; set; }

        [ForeignKey("Cancion")] public Canciones? _Cancion { get; set; }
        [ForeignKey("Compositor")] public Compositores? _Compositor { get; set; }
    }
}
