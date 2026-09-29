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

        public DbSet<Artistas>? Artistas { get; set; }
        public DbSet<Albumes>? Albumes { get; set; }
        public DbSet<Albumes_Artistas>? Albumes_Artistas { get; set; }
        public DbSet<Artistas_Sellos>? Artistas_Sellos { get; set; }
        //public DbSet<Canciones>? Canciones { get; set; }
        public DbSet<Canciones_Compositores>? Canciones_Compositores { get; set; }
    }
}
