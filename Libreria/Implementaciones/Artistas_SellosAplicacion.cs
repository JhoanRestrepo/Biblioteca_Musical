using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Implementaciones
{
    public class Artistas_SellosAplicacion : IArtistas_SellosAplicacion
    {
        private IConexion IConexion;

        public Artistas_SellosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Artistas_Sellos Insertar(Artistas_Sellos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Artista == 0 ||
                entidad.Sello_Discografico == 0)
                throw new Exception("Faltan valores");

            if (!this.IConexion.Artistas!.Any(x => x.Id == entidad.Artista))
                throw new Exception("El artista no existe");

            if (!this.IConexion.Sellos_Discograficos!.Any(x => x.Id == entidad.Sello_Discografico))
                throw new Exception("El sello discográfico no existe");

            if (entidad.Fecha_Inicio == null)
                entidad.Fecha_Inicio = DateTime.Now;

            if (entidad.Fecha_Fin == null)
                entidad.Fecha_Fin = DateTime.Now;

            this.IConexion.Artistas_Sellos!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Artistas_Sellos Actualizar(Artistas_Sellos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (entidad.Artista == 0 ||
                entidad.Sello_Discografico == 0)
                throw new Exception("Faltan valores");

            if (entidad.Fecha_Inicio == null ||
                entidad.Fecha_Fin == null)
                entidad.Fecha_Inicio = DateTime.Now;
                entidad.Fecha_Fin = DateTime.Now;     

            var entry = this.IConexion!.Entry<Artistas_Sellos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Artistas_Sellos> Consultar()
        {
            return this.IConexion.Artistas_Sellos!
                .Include(x => x._Artista)
                .Include(x => x._Sello_Discografico)
                .ToList();
        }

        public Artistas_Sellos Borrar(Artistas_Sellos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.Artistas_Sellos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}