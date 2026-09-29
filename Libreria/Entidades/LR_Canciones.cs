using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Entidades
{
    public class LR_Canciones
    {
        public int Id { get; set; }
        public int Id_Listas_Reproduccion { get; set; }
        public int Id_Cancion { get; set; }

        public Listas_Reproducciones? Lista_Reproduccion { get; set; }
        public Canciones? Cancion { get; set; }
    }
}
