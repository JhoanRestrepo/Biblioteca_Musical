using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Albumes>? Albumes { get; set; }
        public DbSet<Albumes_Artistas>? Albumes_Artistas { get; set; }
        public DbSet<Artistas>? Artistas { get; set; }
        //public DbSet<Artistas_Sellos>? Artistas_Sellos { get; set; }
        //public DbSet<Canciones>? Canciones { get; set; }
        //public DbSet<Canciones_Compositores>? Canciones_Compositores { get; set; }
        //public DbSet<Canciones_Generos>? Canciones_Generos { get; set; }
        //public DbSet<Canciones_Idiomas>? Canciones_Idiomas { get; set; }
        //public DbSet<Compositores>? Compositores { get; set; }
        //public DbSet<Fav_Canciones>? Fav_Canciones { get; set; }
        //public DbSet<Favoritos>? Favoritos { get; set; }
        //public DbSet<Generos>? Generos { get; set; }
        //public DbSet<Idiomas>? Idiomas { get; set; }
        //public DbSet<Listas_Canciones>? Listas_Canciones { get; set; }
        //public DbSet<Listas_Reproducciones>? Listas_Reproducciones { get; set; }
        //public DbSet<LR_Canciones>? LR_Canciones { get; set; }
        //public DbSet<Reproducciones>? Reproducciones { get; set; }
        //public DbSet<Sellos_Discograficos>? Sellos_Discograficos { get; set; }
        //public DbSet<Suscripciones>? Suscripciones { get; set; }
        //public DbSet<Usuarios>? Usuarios { get; set; }
    }
}
