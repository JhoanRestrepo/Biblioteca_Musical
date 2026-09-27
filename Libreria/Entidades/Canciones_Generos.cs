using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria.Entidades
{
    public class Canciones_Generos
    {
        public int Id { get; set; }
        public int Cancion { get; set; }
        public int Genero { get; set; }
        public bool? Principal { get; set; }

        [ForeignKey("Cancion")] public Canciones? _Cancion { get; set; }
        [ForeignKey("Genero")] public Generos? _Genero { get; set; }
    }
}