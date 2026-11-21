using Libreria.Entidades;
using Libreria_Front.Interfaces;

namespace Libreria_Front.Implementaciones
{
    public class CompositoresPresentacion : ICompositoresPresentacion
    {
        private IComunicaciones IComunicaciones;

        public CompositoresPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Compositores Actualizar(Compositores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Compositores>(
                "Compositores/Actualizar", 
                entidad);
            task.Wait();
            return task.Result;
        }

        public Compositores Borrar(Compositores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Compositores>(
                "Compositores/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Compositores> Buscar(Compositores entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Compositores>>(
                "Compositores/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Compositores> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Compositores>>(
                "Compositores/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Compositores Insertar(Compositores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Compositores>(
                "Compositores/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Compositores entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Nacionalidad) ||
                entidad.Fecha_Nacimiento == null;
        }
    }
}