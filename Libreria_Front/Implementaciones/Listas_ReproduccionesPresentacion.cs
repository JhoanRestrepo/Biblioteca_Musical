using Libreria.Entidades;
using Libreria_Front.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Front.Implementaciones
{
    public class Listas_ReproduccionesPresentacion : IListas_ReproduccionesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public Listas_ReproduccionesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Listas_Reproducciones Actualizar(Listas_Reproducciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Listas_Reproducciones>(
                "Listas_Reproducciones/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Listas_Reproducciones Borrar(Listas_Reproducciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Listas_Reproducciones>(
                "Listas_Reproducciones/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Listas_Reproducciones> Buscar(Listas_Reproducciones entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Listas_Reproducciones>>(
                "Listas_Reproducciones/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Listas_Reproducciones> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Listas_Reproducciones>>(
                "Listas_Reproducciones/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Listas_Reproducciones Insertar(Listas_Reproducciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Listas_Reproducciones>(
                "Listas_Reproducciones/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Listas_Reproducciones entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                entidad.Fecha_Creacion == null ||
                string.IsNullOrEmpty(entidad.Privacidad) ||
                entidad.Usuario == null;
        }
    }
}
