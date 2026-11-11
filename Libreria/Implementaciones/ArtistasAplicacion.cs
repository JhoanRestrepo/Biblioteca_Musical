using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Implementaciones
{
    public class ArtistasAplicacion : IArtistasAplicacion
    {
        private IConexion IConexion;

        public ArtistasAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Artistas Insertar(Artistas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Nacionalidad))
                throw new Exception("Faltan valores");

            if (entidad.Fecha_Inicio == null)
                entidad.Fecha_Inicio = DateTime.Now;

            this.IConexion.Artistas!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Artistas Actualizar(Artistas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Nacionalidad))
                throw new Exception("Faltan valores");

            if (entidad.Fecha_Inicio == null)
                entidad.Fecha_Inicio = DateTime.Now;

            var entry = this.IConexion!.Entry<Artistas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Artistas> Consultar()
        {
            return this.IConexion.Artistas!
                .ToList();
        }

        public Artistas Borrar(Artistas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.Artistas!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}