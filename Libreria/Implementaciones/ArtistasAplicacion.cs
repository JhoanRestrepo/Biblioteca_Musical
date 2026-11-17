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
                string.IsNullOrEmpty(entidad.Nacionalidad) ||
                string.IsNullOrEmpty(entidad.Biografia))
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
                string.IsNullOrEmpty(entidad.Nacionalidad) ||
                string.IsNullOrEmpty(entidad.Biografia))
                throw new Exception("Faltan valores");

            if (entidad.Fecha_Inicio == null)
                entidad.Fecha_Inicio = DateTime.Now;

            var entry = this.IConexion!.Entry<Artistas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }
        public List<Artistas> Buscar(Artistas entidad)
        {
            return this.IConexion.Artistas!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .Take(10)
                .ToList();
        }

        public List<Artistas> Consultar()
        {
            return this.IConexion.Artistas!
                .Take(10)
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

        private bool Validar(Artistas entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Nacionalidad) ||
                string.IsNullOrEmpty(entidad.Biografia);
        }

        public List<Albumes_Artistas> Buscar(ArtistasAplicacion artista)
        {
            throw new NotImplementedException();
        }
    }
}