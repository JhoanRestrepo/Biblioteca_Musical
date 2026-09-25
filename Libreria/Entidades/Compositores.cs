using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Entidades
{
    internal class Compositores
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Nacionalidad { get; set; }
        public DateTime? Fecha_Nacimiento { get; set; }
    }
}
