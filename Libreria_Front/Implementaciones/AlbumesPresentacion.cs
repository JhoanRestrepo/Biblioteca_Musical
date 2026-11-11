using Libreria.Entidades;
using Libreria_Front.Interfaces;

namespace Libreria_Front.Implementaciones
{
    public class AlbumesPresentacion : IAlbumesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public AlbumesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Albumes Actualizar(Albumes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Albumes>(
                "Albumes/Actualizar", 
                entidad);
            task.Wait();
            return task.Result;
        }

        public Albumes Borrar(Albumes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Albumes>(
                "Albumes/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Albumes> Buscar(Albumes entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Albumes>>(
                "Albumes/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Albumes> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Albumes>>(
                "Albumes/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Albumes Insertar(Albumes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Albumes>(
                "Albumes/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Albumes entidad)
        {
            return string.IsNullOrEmpty(entidad.Titulo) ||
                entidad.Fecha_Lanzamiento == null ||
                string.IsNullOrEmpty(entidad.Portada);
        }
    }
}