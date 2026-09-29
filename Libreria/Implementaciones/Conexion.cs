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
    }
}
