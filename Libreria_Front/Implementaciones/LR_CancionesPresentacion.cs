using Libreria.Entidades;
using Libreria_Front.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Front.Implementaciones
{
    public class LR_CancionesPresentacion : ILR_CancionesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public LR_CancionesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public LR_Canciones Actualizar(LR_Canciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<LR_Canciones>(
                "LR_Canciones/Actualizar", 
                entidad);
            task.Wait();
            return task.Result;
        }

        public LR_Canciones Borrar(LR_Canciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<LR_Canciones>(
                "LR_Canciones/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<LR_Canciones> Buscar(LR_Canciones entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<LR_Canciones>>(
                "LR_Canciones/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<LR_Canciones> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<LR_Canciones>>(
                "LR_Canciones/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public LR_Canciones Insertar(LR_Canciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<LR_Canciones>(
                "LR_Canciones/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(LR_Canciones entidad)
        {
            return entidad.Lista_Reproduccion == 0 ||
                entidad.Cancion == 0;



        }
    }
}
