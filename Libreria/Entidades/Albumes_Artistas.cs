using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria.Entidades
{
    internal class Albumes_Artistas
    {
        public int Id { get; set; }
        public int Id_Album { get; set; }
        public int Id_Artista { get; set; }

        [ForeignKey("Album")] public Albumes? _Album { get; set; }
        [ForeignKey("Artista")] public Artistas? _Artista { get; set; }
    }
}
