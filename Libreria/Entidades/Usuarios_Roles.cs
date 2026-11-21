using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria.Entidades
{
    public class Usuarios_Roles
    {
        public int Id { get; set; }
        public int Usuario { get; set; }
        public int Rol { get; set; }

        [ForeignKey("Usuario")] public Usuarios? _Usuario { get; set; }
        [ForeignKey("Rol")] public Roles? _Rol { get; set; }
    }
}
