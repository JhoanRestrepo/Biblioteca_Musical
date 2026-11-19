using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Entidades
{
    public class Roles
    {
        public int Id { get; set; }
        public string? Administrador { get; set; }
        public int? Descripcion { get; set; }
        public string? Usuario { get; set; }
    }
}
