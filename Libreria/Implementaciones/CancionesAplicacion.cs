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

            if (string.IsNullOrEmpty(entidad.Titulo))
                throw new Exception("Faltan valores");

            this.IConexion.Canciones!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Canciones Actualizar(Canciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (string.IsNullOrEmpty(entidad.Titulo))
                throw new Exception("Faltan valores");

            var entry = this.IConexion!.Entry<Canciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Canciones> Buscar(Canciones entidad)
        {
            return this.IConexion.Canciones!
                .Where(x => x.Titulo!.Contains(entidad.Titulo!))
                .Take(10)
                .ToList();
        }

        public List<Canciones> Consultar()
        {
            return this.IConexion.Canciones!
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
    }
}
