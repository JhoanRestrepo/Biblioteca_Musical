using Libreria.Entidades;
using Libreria_Front.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Front.Implementaciones
{
    public class Listas_CancionesPresentacion : IListas_CancionesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public Listas_CancionesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Listas_Canciones Actualizar(Listas_Canciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Listas_Canciones>(
                "Listas_Canciones/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Listas_Canciones Borrar(Listas_Canciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Listas_Canciones>(
                "Listas_Canciones/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Listas_Canciones> Buscar(Listas_Canciones entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Listas_Canciones>>(
                "Listas_Canciones/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Listas_Canciones> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Listas_Canciones>>(
                "Listas_Canciones/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Listas_Canciones Insertar(Listas_Canciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Listas_Canciones>(
                "Listas_Canciones/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Listas_Canciones entidad)
        {
            return entidad.Cancion == null ||
                entidad.Posicion == null ||
                entidad.Fecha_Agregada == null ||
                entidad.Favorita == null;
        }
    }
}
