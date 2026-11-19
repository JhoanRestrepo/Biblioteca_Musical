using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Implementaciones
{
    public class IdiomasAplicacion : IIdiomasAplicacion
    {
        private IConexion IConexion;

        public IdiomasAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Idiomas Insertar(Idiomas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Codigo) ||
                string.IsNullOrEmpty(entidad.Descripcion))
                throw new Exception("Faltan valores");

            this.IConexion.Idiomas!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Idiomas Actualizar(Idiomas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Codigo) ||
                string.IsNullOrEmpty(entidad.Descripcion))
                throw new Exception("Faltan valores");

            var entry = this.IConexion!.Entry<Idiomas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Idiomas> Buscar(Idiomas entidad)
        {
            return this.IConexion.Idiomas!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .Take(10)
                .ToList();
        }

        public List<Idiomas> Consultar()
        {
            return this.IConexion.Idiomas!
                .Take(10)
                .ToList();
        }

        public Idiomas Borrar(Idiomas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.Idiomas!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Idiomas entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Codigo) ||
                string.IsNullOrEmpty(entidad.Descripcion);
        }
    }
}
