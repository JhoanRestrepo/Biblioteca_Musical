using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Entidades
{
    public class Suscripciones
    {
        public int Id { get; set; }
        public int Id_Usuario { get; set; }
        public string? Tipo_Plan { get; set; }
        public DateTime? Fecha_Inicio { get; set; }
        public DateTime? Fecha_Fin { get; set; }

        public Usuarios? Usuario { get; set; }
    }
}
    