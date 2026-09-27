using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria.Entidades
{
    public class Artistas_Sellos
    {
        public int Id { get; set; }
        public int Artista { get; set; }
        public int Sello_Discografico { get; set; }
        public DateTime? Fecha_Inicio { get; set; }
        public DateTime? Fecha_Fin { get; set; }
        public string? Contrato { get; set; }

        [ForeignKey("Artista")] public Artistas? _Artista { get; set; }
        [ForeignKey("Sello_Discografico")] public Sellos_Discograficos? _Sello_Discografico { get; set; }

    }
}
