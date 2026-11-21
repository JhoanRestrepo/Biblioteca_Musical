using Libreria.Entidades;
using Libreria_Front.Interfaces;

namespace Libreria_Front.Implementaciones
{
    public class RolesPresentacion : IRolesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public RolesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Roles Actualizar(Roles entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Roles>(
                "Roles/Actualizar", 
                entidad);
            task.Wait();
            return task.Result;
        }

        public Roles Borrar(Roles entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Roles>(
                "Roles/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Roles> Buscar(Roles entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Roles>>(
                "Roles/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Roles> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Roles>>(
                "Roles/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Roles Insertar(Roles entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Roles>(
                "Roles/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Roles entidad)
        {
            return string.IsNullOrEmpty(entidad.Descripcion);
        }
    }
}