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

            if (string.IsNullOrEmpty(entidad.Usuario) ||
                string.IsNullOrEmpty(entidad.Cancion) ||
                string.IsNullOrEmpty(entidad.Fecha_Hora) ||
                    string.IsNullOrEmpty(entidad.Duracion))
                throw new Exception("Faltan valores");

            this.IConexion.Reproducciones!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Reproducciones Actualizar(Reproducciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (string.IsNullOrEmpty(entidad.Usuario) ||
                string.IsNullOrEmpty(entidad.Cancion) ||
                string.IsNullOrEmpty(entidad.Fecha_Hora) ||
                    string.IsNullOrEmpty(entidad.Duracion))
                throw new Exception("Faltan valores");

            var entry = this.IConexion!.Entry<Reproducciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Reproducciones> Buscar(Reproducciones entidad)
        {
            return this.IConexion.Reproducciones!
                .Where(x => x.Usuario!.Contains(entidad.Usuario!))
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
