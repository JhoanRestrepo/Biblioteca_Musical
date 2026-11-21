using Libreria.Entidades;
using Libreria_Front.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_Front.Implementaciones
{
    public class Sellos_DiscograficosPresentacion : ISellos_DiscograficosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public Sellos_DiscograficosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Sellos_Discograficos Actualizar(Sellos_Discograficos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Sellos_Discograficos>(
                "Sellos_Discograficos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Sellos_Discograficos Borrar(Sellos_Discograficos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Sellos_Discograficos>(
                "Sellos_Discograficos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Sellos_Discograficos> Buscar(Sellos_Discograficos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Sellos_Discograficos>>(
                "Sellos_Discograficos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Sellos_Discograficos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Sellos_Discograficos>>(
                "Sellos_Discograficos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Sellos_Discograficos Insertar(Sellos_Discograficos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Sellos_Discograficos>(
                "Sellos_Discograficos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Sellos_Discograficos entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Pais) ||
                entidad.Fecha_Fundacion == null ||
                string.IsNullOrEmpty(entidad.Sitio_Web);
        }
    }
}
