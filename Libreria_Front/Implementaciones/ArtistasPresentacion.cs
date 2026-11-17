using Libreria.Entidades;
using Libreria_Front.Interfaces;

namespace Libreria_Front.Implementaciones
{
    public class ArtistasPresentacion : IArtistasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ArtistasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Artistas Actualizar(Artistas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Artistas>(
                "Artistas/Actualizar", 
                entidad);
            task.Wait();
            return task.Result;
        }

        public Artistas Borrar(Artistas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Artistas>(
                "Artistas/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Artistas> Buscar(Artistas entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Artistas>>(
                "Artistas/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Artistas> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Artistas>>(
                "Artistas/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Artistas Insertar(Artistas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Artistas>(
                "Artistas/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Artistas entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Nacionalidad) ||
                entidad.Fecha_Inicio == null ||
                string.IsNullOrEmpty(entidad.Biografia);
        }
    }
}