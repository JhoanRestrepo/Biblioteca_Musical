using Libreria.Entidades;
using Libreria_Front.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Front.Implementaciones
{
    public class SuscripcionesPresentacion : ISuscripcionesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public SuscripcionesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Suscripciones Actualizar(Suscripciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Suscripciones>(
                "Suscripciones/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Suscripciones Borrar(Suscripciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Suscripciones>(
                "Suscripciones/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Suscripciones> Buscar(Suscripciones entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Suscripciones>>(
                "Suscripciones/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Suscripciones> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Suscripciones>>(
                "Suscripciones/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Suscripciones Insertar(Suscripciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Suscripciones>(
                "Suscripciones/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Suscripciones entidad)
        {
            return entidad.Usuario == 0||
                string.IsNullOrEmpty(entidad.Tipo_Plan) ||
                entidad.Fecha_Inicio == null ||
                entidad.Fecha_Fin == null;
        }
    }
}
