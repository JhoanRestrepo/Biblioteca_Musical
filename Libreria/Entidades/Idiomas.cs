using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Entidades
{
    public class Idiomas
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Codigo { get; set; }
        public string? Descipción { get; set; }
        public bool? Activo { get; set; }

        public List<Canciones_Idiomas>? Canciones_Idiomas { get; set; }
    }
}
