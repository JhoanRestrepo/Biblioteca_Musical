using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Implementaciones
{
    public class Listas_CancionesAplicacion : IListas_CancionesAplicacion
    {
        private IConexion IConexion;

        public Listas_CancionesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Listas_Canciones Insertar(Listas_Canciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Cancion == 0 ||
                entidad.Posicion == 0 ||
                entidad.Favorita == 0)
                throw new Exception("Faltan valores");

            if (!this.IConexion.Canciones!.Any(x => x.Id == entidad.Cancion))
                throw new Exception("La canción no existe");

            if (!this.IConexion.Favoritos!.Any(x => x.Id == entidad.Favorita))
                throw new Exception("La lista no existe");

            this.IConexion.Listas_Canciones!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Listas_Canciones Actualizar(Listas_Canciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (entidad.Cancion == 0 ||
                entidad.Posicion == 0 ||
                entidad.Favorita == 0)
                throw new Exception("Faltan valores");

            var entry = this.IConexion!.Entry<Listas_Canciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Listas_Canciones> Buscar(Listas_Canciones entidad)
        {
            return this.IConexion.Listas_Canciones!
                .Include(x => x._Cancion)
                .Include(x => x._Favorita)
                .Where(x => x._Cancion!.Titulo!.Contains(entidad._Cancion!.Titulo!) ||
                            x._Favorita != null)
                .Take(10)
                .ToList();
        }

        public List<Listas_Canciones> Consultar()
        {
            return this.IConexion.Listas_Canciones!
                .Take(10)
                .ToList();
        }

        public Listas_Canciones Borrar(Listas_Canciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.Listas_Canciones!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Listas_Canciones entidad)
        {
            return string.IsNullOrEmpty(entidad.Cancion.ToString()) ||
                string.IsNullOrEmpty(entidad.Posicion.ToString()) ||
                string.IsNullOrEmpty(entidad.Favorita.ToString());
        }
    }
}
