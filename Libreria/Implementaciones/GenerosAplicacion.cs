using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Implementaciones
{
    public class GenerosAplicacion : IGenerosAplicacion
    {
        private IConexion IConexion;

        public GenerosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Generos Insertar(Generos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Descripcion))
                throw new Exception("Faltan valores");

            this.IConexion.Generos!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Generos Actualizar(Generos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Descripcion))
                throw new Exception("Faltan valores");

            var entry = this.IConexion!.Entry<Generos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Generos> Buscar(Generos entidad)
        {
            return this.IConexion.Generos!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .Take(10)
                .ToList();
        }

        public List<Generos> Consultar()
        {
            return this.IConexion.Generos!
                .Take(10)
                .ToList();
        }

        public Generos Borrar(Generos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.Generos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
