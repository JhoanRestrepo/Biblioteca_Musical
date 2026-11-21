using Libreria.Entidades;
using Libreria_Front.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Front.Implementaciones
{
    public class Canciones_CompositoresPresentacion : ICanciones_CompositoresPresentacion
    {
        private IComunicaciones IComunicaciones;

        public Canciones_CompositoresPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Canciones_Compositores Actualizar(Canciones_Compositores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Canciones_Compositores>(
                "Canciones_Compositores/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Canciones_Compositores Borrar(Canciones_Compositores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Canciones_Compositores>(
                "Canciones_Compositores/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Canciones_Compositores> Buscar(Canciones_Compositores entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Canciones_Compositores>>(
                "Canciones_Compositores/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Canciones_Compositores> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Canciones_Compositores>>(
                "Canciones_Compositores/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Canciones_Compositores Insertar(Canciones_Compositores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Canciones_Compositores>(
                "Canciones_Compositores/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Canciones_Compositores entidad)
        {
            return entidad.Cancion == null ||
                entidad.Compositor == null ||
                entidad.Porcentaje_Autoria == null ||
                entidad.Fecha_Registro == null;
        }
    }
}
