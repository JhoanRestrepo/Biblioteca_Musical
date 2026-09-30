using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria.Entidades
{
    public class LR_Canciones
    {
        public int Id { get; set; }
        public int Lista_Reproduccion { get; set; }
        public int Cancion { get; set; }

        [ForeignKey("Lista_Reproduccion")] public Listas_Reproducciones? _Lista_Reproduccion { get; set; }
        [ForeignKey("Cancion")] public Canciones? _Cancion { get; set; }
    }
}
