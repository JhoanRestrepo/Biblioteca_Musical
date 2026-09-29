using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Entidades
{
    public class Listas_Reproducciones
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime? Fecha_Creacion { get; set; }
        public string? Privacidad { get; set; }
        public int Id_Usuario { get; set; }

        public Usuarios? Usuario { get; set; }
        public List<LR_Canciones>? LR_Canciones { get; set; }
    }
}
