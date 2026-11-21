using Libreria.Entidades;
using Libreria_Front.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Front.Implementaciones
{
   public class ReproduccionesPresentacion : IReproduccionesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ReproduccionesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Reproducciones Actualizar(Reproducciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Reproducciones>(
                "Reproducciones/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Reproducciones Borrar(Reproducciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Reproducciones>(
                "Reproducciones/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Reproducciones> Buscar(Reproducciones entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Reproducciones>>(
                "Reproducciones/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Reproducciones> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Reproducciones>>(
                "Reproducciones/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Reproducciones Insertar(Reproducciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Reproducciones>(
                "Reproducciones/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Reproducciones entidad)
        {
            return entidad.Usuario == 0 ||
                entidad.Cancion == 0 ||
                entidad.Fecha_Hora == null ||
                entidad.Duracion == null;
        }
    }
}
