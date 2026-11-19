using Libreria.Entidades;
using Libreria_Front.Interfaces;

namespace Libreria_Front.Implementaciones
{
    public class CancionesPresentacion : ICancionesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public CancionesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Canciones Actualizar(Canciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Canciones>(
                "Canciones/Actualizar", 
                entidad);
            task.Wait();
            return task.Result;
        }

        public Canciones Borrar(Canciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Canciones>(
                "Canciones/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Canciones> Buscar(Canciones entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Canciones>>(
                "Canciones/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Canciones> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Canciones>>(
                "Canciones/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Canciones Insertar(Canciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Canciones>(
                "Canciones/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Canciones entidad)
        {
            return string.IsNullOrEmpty(entidad.Titulo) ||
                entidad.Duracion == null ||
                entidad.Numero_Pista == 0;
        }
    }
}