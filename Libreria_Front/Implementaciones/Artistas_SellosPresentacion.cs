using Libreria.Entidades;
using Libreria_Front.Interfaces;

namespace Libreria_Front.Implementaciones
{
    public class Artistas_SellosPresentacion : IArtistas_SellosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public Artistas_SellosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Artistas_Sellos Actualizar(Artistas_Sellos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Artistas_Sellos>(
                "Artistas_Sellos/Actualizar", 
                entidad);
            task.Wait();
            return task.Result;
        }

        public Artistas_Sellos Borrar(Artistas_Sellos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Artistas_Sellos>(
                "Artistas_Sellos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Artistas_Sellos> Buscar(Artistas_Sellos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Artistas_Sellos>>(
                "Artistas_Sellos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Artistas_Sellos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Artistas_Sellos>>(
                "Artistas_Sellos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Artistas_Sellos Insertar(Artistas_Sellos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Artistas_Sellos>(
                "Artistas_Sellos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Artistas_Sellos entidad)
        {
            return entidad.Artista == null ||
                entidad.Sello_Discografico == null;



        }
    }
}