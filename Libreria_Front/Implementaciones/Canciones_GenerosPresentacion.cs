using Libreria.Entidades;
using Libreria_Front.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Front.Implementaciones
{
   public class Canciones_GenerosPresentacion : ICanciones_GenerosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public Canciones_GenerosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Canciones_Generos Actualizar(Canciones_Generos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Canciones_Generos>(
                "Canciones_Generos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Canciones_Generos Borrar(Canciones_Generos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Canciones_Generos>(
                "Canciones_Generos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Canciones_Generos> Buscar(Canciones_Generos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Canciones_Generos>>(
                "Canciones_Generos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Canciones_Generos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Canciones_Generos>>(
                "Canciones_Generos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Canciones_Generos Insertar(Canciones_Generos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Canciones_Generos>(
                "Canciones_Generos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Canciones_Generos entidad)
        {
            return entidad.Cancion == null ||
                entidad.Genero == null ||
                entidad.Principal == null;
        }
    }
}
