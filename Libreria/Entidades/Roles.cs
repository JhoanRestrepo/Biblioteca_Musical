using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria.Entidades
{
    public class Roles
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }

        [NotMapped] public List<Usuarios_Roles>? Usuarios_Roles { get; set; }
        [NotMapped] public List<Roles_Permisos>? Roles_Permisos { get; set; }
    }
}
