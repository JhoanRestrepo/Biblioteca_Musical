using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria.Entidades
{
    public class Canciones
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public TimeSpan Duracion { get; set; }
        public int Numero_Pista { get; set; }
        public int Album { get; set; }
        
        [ForeignKey("Album")] public Albumes? _Album { get; set; }

        [NotMapped] public List<Canciones_Compositores>? Canciones_Compositores { get; set; }
        [NotMapped] public List<Fav_Canciones>? Fav_Canciones { get; set; }
        [NotMapped] public List<LR_Canciones>? LR_Canciones { get; set; }
        [NotMapped] public List<Reproducciones>? Reproducciones { get; set; }
        [NotMapped] public List<Listas_Canciones>? Listas_Canciones { get; set; }
        [NotMapped] public List<Canciones_Generos>? Canciones_Generos { get; set; }
        [NotMapped] public List<Canciones_Idiomas>? Canciones_Idiomas { get; set; }
    }
}
