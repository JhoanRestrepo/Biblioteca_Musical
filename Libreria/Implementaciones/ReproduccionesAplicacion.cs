using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Implementaciones
{
    public class ReproduccionesAplicacion : IReproduccionesAplicacion
    {
        private IConexion IConexion;

        public ReproduccionesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Reproducciones Insertar(Reproducciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.IConexion.Reproducciones!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Reproducciones Actualizar(Reproducciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            var entry = this.IConexion!.Entry<Reproducciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Reproducciones> Buscar(Reproducciones entidad)
        {
            return this.IConexion.Reproducciones!
                .Where(x => x.Cancion == entidad.Cancion)
                .Take(10)
                .ToList();
        }

        public List<Reproducciones> Consultar()
        {
            return this.IConexion.Reproducciones!
                .Take(10)
                .ToList();
        }

        public Reproducciones Borrar(Reproducciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.Reproducciones!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
