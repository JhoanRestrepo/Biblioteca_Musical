using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Implementaciones
{
    public class CancionesAplicacion : ICancionesAplicacion
    {
        private IConexion IConexion;

        public CancionesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Canciones Insertar(Canciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (string.IsNullOrEmpty(entidad.Titulo) ||
                entidad.Duracion == TimeSpan.Zero ||
                entidad.Numero_Pista == 0 ||
                entidad.Album == 0)
                throw new Exception("Faltan valores");

            if (!this.IConexion.Albumes!.Any(x => x.Id == entidad.Album))
                throw new Exception("El álbum no existe");

            this.IConexion.Canciones!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Canciones Actualizar(Canciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (string.IsNullOrEmpty(entidad.Titulo) ||
                entidad.Duracion == TimeSpan.Zero ||
                entidad.Numero_Pista == 0 ||
                entidad.Album == 0)
                throw new Exception("Faltan valores");

            var entry = this.IConexion!.Entry<Canciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Canciones> Consultar()
        {
            return this.IConexion.Canciones!
                .Include(x => x._Album)
                .Take(10)
                .ToList();
        }

        public List<Canciones> Buscar(Canciones entidad)
        {
            return this.IConexion.Canciones!
                .Include(x => x._Album)
                .Where(x => x.Titulo!.Contains(entidad.Titulo!))
                .Take(10)
                .ToList();
        }

        public Canciones Borrar(Canciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.Canciones!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Canciones entidad)
        {
            return string.IsNullOrEmpty(entidad.Titulo) ||
                string.IsNullOrEmpty(entidad.Duracion.ToString()) ||
                string.IsNullOrEmpty(entidad.Numero_Pista.ToString()) ||
                string.IsNullOrEmpty(entidad.Album.ToString());
        }
    }
}
