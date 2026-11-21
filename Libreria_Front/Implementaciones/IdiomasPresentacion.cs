using Libreria.Entidades;
using Libreria_Front.Interfaces;

namespace Libreria_Front.Implementaciones
{
    public class IdiomasPresentacion : I_IdiomasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public IdiomasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Idiomas Actualizar(Idiomas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Idiomas>(
                "Idiomas/Actualizar", 
                entidad);
            task.Wait();
            return task.Result;
        }

        public Idiomas Borrar(Idiomas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Idiomas>(
                "Idiomas/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Idiomas> Buscar(Idiomas entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Idiomas>>(
                "Idiomas/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Idiomas> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Idiomas>>(
                "Idiomas/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Idiomas Insertar(Idiomas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Idiomas>(
                "Idiomas/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Idiomas entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Codigo) ||
                string.IsNullOrEmpty(entidad.Descripcion) ||
                entidad.Activo == null;
        }
    }
}