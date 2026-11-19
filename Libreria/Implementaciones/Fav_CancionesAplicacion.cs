using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Implementaciones
{
    public class Fav_CancionesAplicacion : IFav_CancionesAplicacion
    {
        private IConexion IConexion;

        public Fav_CancionesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Fav_Canciones Insertar(Fav_Canciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Favorito == 0 ||
                entidad.Cancion == 0)
                throw new Exception("Faltan valores");

            if (!this.IConexion.Favoritos!.Any(x => x.Id == entidad.Favorito))
                throw new Exception("El favorito no existe");

            if (!this.IConexion.Canciones!.Any(x => x.Id == entidad.Cancion))
                throw new Exception("La canción no existe");

            this.IConexion.Fav_Canciones!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Fav_Canciones Actualizar(Fav_Canciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (entidad.Favorito == 0 ||
                entidad.Cancion == 0)
                throw new Exception("Faltan valores");

            var entry = this.IConexion!.Entry<Fav_Canciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Fav_Canciones> Consultar()
        {
            return this.IConexion.Fav_Canciones!
                .Include(x => x._Favorito)
                .Include(x => x._Cancion)
                .Take(10)
                .ToList();
        }

        public List<Fav_Canciones> Buscar(Fav_Canciones entidad)
        {
            return this.IConexion.Fav_Canciones!
                .Include(x => x._Favorito)
                .Include(x => x._Cancion)
                .Where(x => x._Cancion!.Titulo!.Contains(entidad._Cancion!.Titulo!))
                .Take(10)
                .ToList();
        }

        public Fav_Canciones Borrar(Fav_Canciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.Fav_Canciones!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Fav_Canciones entidad)
        {
            return string.IsNullOrEmpty(entidad.Favorito.ToString()) ||
                string.IsNullOrEmpty(entidad.Cancion.ToString());
        }
    }
}
