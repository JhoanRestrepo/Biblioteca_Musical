using Libreria.Entidades;
using Libreria_Front.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Front.Implementaciones
{
   public class FavoritosPresentacion : IFavoritosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public FavoritosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Favoritos Actualizar(Favoritos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Favoritos>(
                "Favoritos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Favoritos Borrar(Favoritos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Favoritos>(
                "Favoritos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Favoritos> Buscar(Favoritos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Favoritos>>(
                "Favoritos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Favoritos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Favoritos>>(
                "Favoritos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Favoritos Insertar(Favoritos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Favoritos>(
                "Favoritos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Favoritos entidad)
        {
            return entidad.Usuario == null ||
                entidad.Fecha_Marcado == null ||
                entidad.Activo == null;
        }
    }
}
