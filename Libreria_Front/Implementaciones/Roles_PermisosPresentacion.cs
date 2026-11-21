using Libreria.Entidades;
using Libreria_Front.Interfaces;

namespace Libreria_Front.Implementaciones
{
    public class Roles_PermisosPresentacion : IRoles_PermisosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public Roles_PermisosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Roles_Permisos Actualizar(Roles_Permisos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Roles_Permisos>(
                "Roles_Permisos/Actualizar", 
                entidad);
            task.Wait();
            return task.Result;
        }

        public Roles_Permisos Borrar(Roles_Permisos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Roles_Permisos>(
                "Roles_Permisos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Roles_Permisos> Buscar(Roles_Permisos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Roles_Permisos>>(
                "Roles_Permisos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Roles_Permisos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Roles_Permisos>>(
                "Roles_Permisos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Roles_Permisos Insertar(Roles_Permisos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Roles_Permisos>(
                "Roles_Permisos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Roles_Permisos entidad)
        {
            return entidad.Rol == 0 ||
                entidad.Permiso == 0;



        }
    }
}