using Libreria.Entidades;
using Libreria_Front.Interfaces;

namespace Libreria_Front.Implementaciones
{
    public class GenerosPresentacion : IGenerosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public GenerosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Generos Actualizar(Generos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Generos>(
                "Generos/Actualizar", 
                entidad);
            task.Wait();
            return task.Result;
        }

        public Generos Borrar(Generos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Generos>(
                "Generos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Generos> Buscar(Generos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Generos>>(
                "Generos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Generos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Generos>>(
                "Generos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Generos Insertar(Generos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Generos>(
                "Generos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Generos entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Descripcion) ||
                entidad.Popularidad == 0;
        }
    }
}