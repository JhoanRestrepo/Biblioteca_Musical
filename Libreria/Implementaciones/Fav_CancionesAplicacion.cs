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

            this.IConexion.Fav_Canciones!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Fav_Canciones Actualizar(Fav_Canciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            var entry = this.IConexion!.Entry<Fav_Canciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Fav_Canciones> Buscar(Fav_Canciones entidad)
        {
            return this.IConexion.Fav_Canciones!
                .Where(x => x.Cancion == entidad.Cancion)
                .Take(10)
                .ToList();
        }

        public List<Fav_Canciones> Consultar()
        {
            return this.IConexion.Fav_Canciones!
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
    }
}
