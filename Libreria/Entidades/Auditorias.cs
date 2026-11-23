using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria.Entidades
{
    public class Auditorias
    {
        public int Id { get; set; }
        public string? Accion { get; set; }
        public int? Usuario { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("Usuario")] public Usuarios? _Usuario { get; set; }

    }
}