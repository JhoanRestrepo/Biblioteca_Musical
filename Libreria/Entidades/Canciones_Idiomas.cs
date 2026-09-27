using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria.Entidades
{
    public class Canciones_Idiomas
    {
        public int Id { get; set; }
        public int Cancion { get; set; }
        public int Idioma { get; set; }
        public string? Idioma_Principal { get; set; }
        public float? Porcentaje_Idioma { get; set; }
        public DateTime? Fecha_Registro { get; set; }

        [ForeignKey("Cancion")] public Canciones? _Cancion { get; set; }
        [ForeignKey("Idioma")] public Idiomas? _Idioma { get; set; }
    }
}
