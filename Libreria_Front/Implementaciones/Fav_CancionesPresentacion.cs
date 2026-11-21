using Libreria.Entidades;
using Libreria_Front.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Front.Implementaciones
{
   public class Fav_CancionesPresentacion : IFav_CancionesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public Fav_CancionesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Fav_Canciones Actualizar(Fav_Canciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Fav_Canciones>(
                "Fav_Canciones/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Fav_Canciones Borrar(Fav_Canciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Fav_Canciones>(
                "Fav_Canciones/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Fav_Canciones> Buscar(Fav_Canciones entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Fav_Canciones>>(
                "Fav_Canciones/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Fav_Canciones> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Fav_Canciones>>(
                "Fav_Canciones/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Fav_Canciones Insertar(Fav_Canciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Fav_Canciones>(
                "Fav_Canciones/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Fav_Canciones entidad)
        {
            return entidad.Favorito == null ||
                entidad.Cancion == null;
        }
    }
}
