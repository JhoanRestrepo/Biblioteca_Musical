using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria.Entidades
{
    public class Usuarios
        {
            public int Id { get; set; }
            public string? Nombre { get; set; }
            public string? Apellido { get; set; }
            public string? Correo { get; set; }
            public DateTime? Fecha_Registro { get; set; }

            public List<Suscripciones>? Suscripciones { get; set; }
            public List<Listas_Reproducciones>? Listas_Reproducciones { get; set; }
            public List<Favoritos>? Favoritos { get; set; }
            public List<Reproducciones>? Reproducciones { get; set; }
        }
    }


