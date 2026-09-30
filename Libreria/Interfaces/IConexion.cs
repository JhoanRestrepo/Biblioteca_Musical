using Libreria.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }


        DbSet<Albumes>? Albumes { get; set; }
        DbSet<Albumes_Artistas>? Albumes_Artistas { get; set; }
        DbSet<Artistas>? Artistas { get; set; }
        //DbSet<Artistas_Sellos>? Artistas_Sellos { get; set; }
        //DbSet<Canciones>? Canciones { get; set; }
        DbSet<Canciones_Compositores>? Canciones_Compositores { get; set; }
        //DbSet<Canciones_Generos>? Canciones_Generos { get; set; }
        //DbSet<Canciones_Idiomas>? Canciones_Idiomas { get; set; }
        //DbSet<Compositores>? Compositores { get; set; }
        //DbSet<Fav_Canciones>? Fav_Canciones { get; set; }
        //DbSet<Favoritos>? Favoritos { get; set; }
        //DbSet<Generos>? Generos { get; set; }
        //DbSet<Idiomas>? Idiomas { get; set; }
        //DbSet<Listas_Canciones>? Listas_Canciones { get; set; }
        //DbSet<Listas_Reproducciones>? Listas_Reproducciones { get; set; }
        //DbSet<LR_Canciones>? LR_Canciones { get; set; }
        //DbSet<Reproducciones>? Reproducciones { get; set; }
        //DbSet<Sellos_Discograficos> Sellos_Discograficos { get; set; }
        //DbSet<Suscripciones>? Suscripciones { get; set; }
        //DbSet<Usuarios>? Usuarios { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
