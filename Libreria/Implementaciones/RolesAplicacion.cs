using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Implementaciones
{
    public class RolesAplicacion : IRolesAplicacion
    {
        private IConexion IConexion;

        public RolesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Roles Insertar(Roles entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (string.IsNullOrEmpty(entidad.Administrador) ||
                entidad.Descripcion == null ||
                string.IsNullOrEmpty(entidad.Usuario))
                throw new Exception("Faltan valores");

            this.IConexion.Roles!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Roles Actualizar(Roles entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (string.IsNullOrEmpty(entidad.Administrador) ||
                entidad.Descripcion == null ||
                string.IsNullOrEmpty(entidad.Usuario))
                throw new Exception("Faltan valores");

            var entry = this.IConexion!.Entry<Roles>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Roles> Buscar(Roles entidad)
        {
            return this.IConexion.Roles!
                .Where(x => x.Administrador!.Contains(entidad.Administrador!))
                .Take(10)
                .ToList();
        }

        public List<Roles> Consultar()
        {
            return this.IConexion.Roles!
                .Take(10)
                .ToList();
        }

        public Roles Borrar(Roles entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.Roles!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Roles entidad)
        {
            return string.IsNullOrEmpty(entidad.Administrador) ||
                string.IsNullOrEmpty(entidad.Descripcion.ToString()) ||
                string.IsNullOrEmpty(entidad.Usuario);
        }
    }
}
