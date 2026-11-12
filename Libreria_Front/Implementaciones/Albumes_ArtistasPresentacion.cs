using Libreria.Entidades;
using Libreria_Front.Interfaces;

namespace Libreria_Front.Implementaciones
{
    public class Albumes_ArtistasPresentacion : IAlbumes_ArtistasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public Albumes_ArtistasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Albumes_Artistas Actualizar(Albumes_Artistas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Albumes_Artistas>(
                "Albumes_Artistas/Actualizar", 
                entidad);
            task.Wait();
            return task.Result;
        }

        public Albumes_Artistas Borrar(Albumes_Artistas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Albumes_Artistas>(
                "Albumes_Artistas/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Albumes_Artistas> Buscar(Albumes_Artistas entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Albumes_Artistas>>(
                "Albumes_Artistas/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Albumes_Artistas> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Albumes_Artistas>>(
                "Albumes_Artistas/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Albumes_Artistas Insertar(Albumes_Artistas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Albumes_Artistas>(
                "Albumes_Artistas/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Albumes_Artistas entidad)
        {
            return entidad.Album == null ||
                entidad.Artista == null;



        }
    }
}