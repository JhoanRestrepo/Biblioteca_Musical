using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Implementaciones
{
    public class AlbumesAplicacion : IAlbumesAplicacion
    {
        private IConexion IConexion;

        public AlbumesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Albumes Insertar(Albumes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (string.IsNullOrEmpty(entidad.Titulo) ||
                string.IsNullOrEmpty(entidad.Portada))
                throw new Exception("Faltan valores");

            if (entidad.Fecha_Lanzamiento == null)
                entidad.Fecha_Lanzamiento = DateTime.Now;

            this.IConexion.Albumes!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Albumes Actualizar(Albumes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (string.IsNullOrEmpty(entidad.Titulo))
                throw new Exception("Faltan valores");

            if (entidad.Fecha_Lanzamiento == null)
                entidad.Fecha_Lanzamiento = DateTime.Now;

            var entry = this.IConexion!.Entry<Albumes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Albumes> Buscar(Albumes entidad)
        {
            return this.IConexion.Albumes!
                .Where(x => x.Titulo!.Contains(entidad.Titulo!))
                .Take(10)
                .ToList();
        }

        public List<Albumes> Consultar()
        {
            return this.IConexion.Albumes!
                .Take(10)
                .ToList();
        }

        public Albumes Borrar(Albumes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.Albumes!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Albumes entidad)
        {
            return string.IsNullOrEmpty(entidad.Titulo) ||
                string.IsNullOrEmpty(entidad.Portada) ||
                entidad.Fecha_Lanzamiento == null;
        }

        public List<Albumes_Artistas> Buscar(AlbumesAplicacion album)
        {
            throw new NotImplementedException();
        }
    }
}