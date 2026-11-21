using Libreria.Entidades;
using Libreria_Front.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Front.Implementaciones
{
   public class Canciones_IdiomasPresentacion : ICanciones_IdiomasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public Canciones_IdiomasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Canciones_Idiomas Actualizar(Canciones_Idiomas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Canciones_Idiomas>(
                "Canciones_Idiomas/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Canciones_Idiomas Borrar(Canciones_Idiomas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Canciones_Idiomas>(
                "Canciones_Idiomas/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Canciones_Idiomas> Buscar(Canciones_Idiomas entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Canciones_Idiomas>>(
                "Canciones_Idiomas/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Canciones_Idiomas> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Canciones_Idiomas>>(
                "Canciones_Idiomas/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Canciones_Idiomas Insertar(Canciones_Idiomas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Canciones_Idiomas>(
                "Canciones_Idiomas/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Canciones_Idiomas entidad)
        {
            return entidad.Cancion == null ||
                entidad.Idioma == null ||
                entidad.Porcentaje == null ||
                entidad.Fecha_Registro == null;
        }
    }
}
