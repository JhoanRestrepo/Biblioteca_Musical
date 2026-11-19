using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Implementaciones
{
    public class PermisosAplicacion : IPermisosAplicacion
    {
        private IConexion IConexion;

        public PermisosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Permisos Insertar(Permisos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Codigo) ||
                string.IsNullOrEmpty(entidad.Descripcion))
                throw new Exception("Faltan valores");

            this.IConexion.Permisos!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Permisos Actualizar(Permisos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Codigo) ||
                string.IsNullOrEmpty(entidad.Descripcion))
                throw new Exception("Faltan valores");

            var entry = this.IConexion!.Entry<Permisos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Permisos> Buscar(Permisos entidad)
        {
            return this.IConexion.Permisos!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .Take(10)
                .ToList();
        }

        public List<Permisos> Consultar()
        {
            return this.IConexion.Permisos!
                .Take(10)
                .ToList();
        }

        public Permisos Borrar(Permisos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.Permisos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
