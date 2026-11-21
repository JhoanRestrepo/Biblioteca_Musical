using Libreria.Entidades;
using Libreria_Front.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Front.Implementaciones
{
    public class PermisosPresentacion : IPermisosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public PermisosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Permisos Actualizar(Permisos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Permisos>(
                "Permisos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Permisos Borrar(Permisos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Permisos>(
                "Permisos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Permisos> Buscar(Permisos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Permisos>>(
                "Permisos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Permisos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Permisos>>(
                "Permisos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Permisos Insertar(Permisos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Permisos>(
                "Permisos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Permisos entidad)
        {
            return String.IsNullOrEmpty(entidad.Nombre) ||
                String.IsNullOrEmpty(entidad.Codigo) ||
                String.IsNullOrEmpty(entidad.Descripcion);
        }
    }
}
