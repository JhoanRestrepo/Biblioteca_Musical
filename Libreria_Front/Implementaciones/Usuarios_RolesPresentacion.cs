using Libreria.Entidades;
using Libreria_Front.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Front.Implementaciones
{
    public class Usuarios_RolesPresentacion : IUsuarios_RolesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public Usuarios_RolesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Usuarios_Roles Actualizar(Usuarios_Roles entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Usuarios_Roles>(
                "Usuarios_Roles/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Usuarios_Roles Borrar(Usuarios_Roles entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Usuarios_Roles>(
                "Usuarios_Roles/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Usuarios_Roles> Buscar(Usuarios_Roles entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Usuarios_Roles>>(
                "Usuarios_Roles/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Usuarios_Roles> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Usuarios_Roles>>(
                "Usuarios_Roles/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Usuarios_Roles Insertar(Usuarios_Roles entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Usuarios_Roles>(
                "Usuarios_Roles/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Usuarios_Roles entidad)
        {
            return entidad.Usuario == 0 ||
                entidad.Rol == 0;



        }
    }
}
