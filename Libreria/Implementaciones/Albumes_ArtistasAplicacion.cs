using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Implementaciones
{
    public class Albumes_ArtistasAplicacion : IAlbumes_ArtistasAplicacion
    {
        private IConexion IConexion;

        public Albumes_ArtistasAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Albumes_Artistas Insertar(Albumes_Artistas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Album == 0 ||
                entidad.Artista == 0)
                throw new Exception("Faltan valores");

            if (!this.IConexion.Albumes!.Any(x => x.Id == entidad.Album))
                throw new Exception("El álbum no existe");

            if (!this.IConexion.Artistas!.Any(x => x.Id == entidad.Artista))
                throw new Exception("El artista no existe");

            this.IConexion.Albumes_Artistas!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Albumes_Artistas Actualizar(Albumes_Artistas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (entidad.Album == 0 ||
                entidad.Artista == 0)
                throw new Exception("Faltan valores");

            var entry = this.IConexion!.Entry<Albumes_Artistas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Albumes_Artistas> Consultar()
        {
            return this.IConexion.Albumes_Artistas!
                .Include(x => x._Album)
                .Include(x => x._Artista)
                .Take(10)
                .ToList();
        }

        public Albumes_Artistas Borrar(Albumes_Artistas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.Albumes_Artistas!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Albumes_Artistas entidad)
        {
            return string.IsNullOrEmpty(entidad.Album.ToString()) ||
                string.IsNullOrEmpty(entidad.Artista.ToString());
        }
    }
}