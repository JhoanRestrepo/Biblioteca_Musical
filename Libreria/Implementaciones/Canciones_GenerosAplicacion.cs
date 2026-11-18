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

            this.IConexion.Canciones_Generos!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Canciones_Generos Actualizar(Canciones_Generos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            var entry = this.IConexion!.Entry<Canciones_Generos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Canciones_Generos> Buscar(Canciones_Generos entidad)
        {
            return this.IConexion.Canciones_Generos!
                .Where(x => x.Cancion == entidad.Cancion)
                .Take(10)
                .ToList();
        }

        public List<Canciones_Generos> Consultar()
        {
            return this.IConexion.Canciones_Generos!
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
    }
}
