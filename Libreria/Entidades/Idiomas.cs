using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria.Entidades
{
    public class Idiomas
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public bool? Activo { get; set; }

        [NotMapped] public List<Canciones_Idiomas>? Canciones_Idiomas { get; set; }
    }
}