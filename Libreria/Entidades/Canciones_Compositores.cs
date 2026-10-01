using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria.Entidades
{
    public class Canciones_Compositores
    {
        public int Id { get; set; }
        public int Cancion { get; set; }
        public int Compositor { get; set; }
        public decimal Porcentaje_Autoria { get; set; }
        public DateTime Fecha_Registro { get; set; }

        [ForeignKey("Cancion")] public Canciones? _Cancion { get; set; }
        [ForeignKey("Compositor")] public Compositores? _Compositor { get; set; }
    }
}
