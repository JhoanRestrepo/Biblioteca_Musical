using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Implementaciones
{
    public class Roles_PermisosAplicacion : IRoles_PermisosAplicacion
    {
        private IConexion IConexion;

        public Roles_PermisosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Roles_Permisos Insertar(Roles_Permisos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (entidad._Rol!.Id == 0 ||
                entidad._Permiso!.Id == 0)
                throw new Exception("Faltan valores");

            if (!this.IConexion.Roles!.Any(x => x.Id == entidad.Rol))
                throw new Exception("El rol no existe");

            if (!this.IConexion.Permisos!.Any(x => x.Id == entidad.Permiso))
                throw new Exception("El permiso no existe");

            this.IConexion.Roles_Permisos!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Roles_Permisos Actualizar(Roles_Permisos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (entidad.Rol == 0 ||
                entidad.Permiso == 0)
                throw new Exception("Faltan valores");

            var entry = this.IConexion!.Entry<Roles_Permisos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Roles_Permisos> Buscar(Roles_Permisos entidad)
        {
            return this.IConexion.Roles_Permisos!
                .Include(x => x._Rol)
                .Include(x => x._Permiso)
                .Where(x => x._Rol!.Descripcion!.Contains(entidad._Rol!.Descripcion!) ||
                            x._Permiso!.Nombre!.Contains(entidad._Permiso!.Nombre!))
                .Take(10)
                .ToList();
        }

        public List<Roles_Permisos> Consultar()
        {
            return this.IConexion.Roles_Permisos!
                .Include(x => x._Rol)
                .Include(x => x._Permiso)
                .Take(10)
                .ToList();
        }

        public Roles_Permisos Borrar(Roles_Permisos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.Roles_Permisos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Roles_Permisos entidad)
        {
            return string.IsNullOrEmpty(entidad.Rol.ToString()) ||
                string.IsNullOrEmpty(entidad.Permiso.ToString());
        }
    }
}
