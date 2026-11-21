using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria.Entidades
{
    public class Roles_Permisos
    {
        public int Id { get; set; }
        public int Rol { get; set; }
        public int Permiso { get; set; }

        [ForeignKey("Rol")] public Roles? _Rol { get; set; }
        [ForeignKey("Permiso")] public Permisos? _Permiso { get; set; }
    }
}
