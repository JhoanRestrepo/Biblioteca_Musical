using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria.Entidades
{
    public class Listas_Reproducciones
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime? Fecha_Creacion { get; set; }
        public string? Privacidad { get; set; }
        public int Usuario { get; set; }

        [ForeignKey("Usuario")] public Usuarios? _Usuario { get; set; }
        public List<LR_Canciones>? LR_Canciones { get; set; }
    }
}
