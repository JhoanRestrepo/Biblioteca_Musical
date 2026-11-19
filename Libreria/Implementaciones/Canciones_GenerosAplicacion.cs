using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Implementaciones
{
    public class Canciones_GenerosAplicacion : ICanciones_GenerosAplicacion
    {
        private IConexion IConexion;

        public Canciones_GenerosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Canciones_Generos Insertar(Canciones_Generos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Cancion == 0 ||
                entidad.Genero == 0 ||
                entidad.Principal == null)
                throw new Exception("Faltan valores");

            if (!this.IConexion.Canciones!.Any(x => x.Id == entidad.Cancion))
                throw new Exception("La canción no existe");

            if (!this.IConexion.Generos!.Any(x => x.Id == entidad.Genero))
                throw new Exception("El género no existe");

            this.IConexion.Canciones_Generos!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Canciones_Generos Actualizar(Canciones_Generos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (entidad.Cancion == 0 ||
                entidad.Genero == 0 ||
                entidad.Principal == null)
                throw new Exception("Faltan valores");

            var entry = this.IConexion!.Entry<Canciones_Generos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Canciones_Generos> Consultar()
        {
            return this.IConexion.Canciones_Generos!
                .Include(x => x._Cancion)
                .Include(x => x._Genero)
                .Take(10)
                .ToList();
        }

        public List<Canciones_Generos> Buscar(Canciones_Generos entidad)
        {
            return this.IConexion.Canciones_Generos!
                .Include(x => x._Cancion)
                .Include(x => x._Genero)
                .Where(x => x._Cancion!.Titulo!.Contains(entidad._Cancion!.Titulo!) ||
                            x._Genero!.Nombre!.Contains(entidad._Genero!.Nombre!))
                .Take(10)
                .ToList();
        }

        public Canciones_Generos Borrar(Canciones_Generos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.Canciones_Generos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Canciones_Generos entidad)
        {
            return string.IsNullOrEmpty(entidad.Cancion.ToString()) ||
                string.IsNullOrEmpty(entidad.Genero.ToString()) ||
                string.IsNullOrEmpty(entidad.Principal.ToString());
        }
    }
}
