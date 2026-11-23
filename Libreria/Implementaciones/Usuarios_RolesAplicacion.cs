using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Implementaciones
{
    public class Usuarios_RolesAplicacion : IUsuarios_RolesAplicacion
    {
        private IConexion IConexion;

        public Usuarios_RolesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Usuarios_Roles Insertar(Usuarios_Roles entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Usuario == 0 || entidad.Rol == 0)
                throw new Exception("Faltan valores");

            entidad._Usuario = null;
            entidad._Rol = null;

            if (!this.IConexion.Usuarios!.Any(x => x.Id == entidad.Usuario))
                throw new Exception("El usuario no existe");

            if (!this.IConexion.Roles!.Any(x => x.Id == entidad.Rol))
                throw new Exception("El rol no existe");

            this.IConexion.Usuarios_Roles!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Usuarios_Roles Actualizar(Usuarios_Roles entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (entidad.Usuario == 0 ||
                entidad.Rol == 0)
                throw new Exception("Faltan valores");

            var entry = this.IConexion!.Entry<Usuarios_Roles>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Usuarios_Roles> Buscar(Usuarios_Roles entidad)
        {
            return this.IConexion.Usuarios_Roles!
                .Include(x => x._Usuario)
                .Include(x => x._Rol)
                .Where(x => x._Usuario!.Nombre!.Contains(entidad._Usuario!.Nombre!) ||
                            x._Rol!.Descripcion!.Contains(entidad._Rol!.Descripcion!))
                .Take(10)
                .ToList();
        }

        public List<Usuarios_Roles> Consultar()
        {
            return this.IConexion.Usuarios_Roles!
                .Include(x => x._Usuario)
                .Include(x => x._Rol)
                .Take(10)
                .ToList();
        }

        public Usuarios_Roles Borrar(Usuarios_Roles entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.Usuarios_Roles!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Usuarios_Roles entidad)
        {
            return string.IsNullOrEmpty(entidad.Usuario.ToString()) ||
                string.IsNullOrEmpty(entidad.Rol.ToString());
        }
    }
}
