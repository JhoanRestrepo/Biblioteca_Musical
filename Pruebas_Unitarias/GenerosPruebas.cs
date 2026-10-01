using Libreria.Entidades;
using Libreria.Implementaciones;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pruebas_Unarias
{
    [TestClass]
    public sealed class GenerosPruebas
    {
        private IConexion conexion;
        private Generos? entidad = null;

        public GenerosPruebas()
        {
            this.conexion = new Conexion();
            //this.conexion.StringConexion = Datosgenerales.ObtenerStringConexion();
            //this.conexion.StringConexion = "server=localhost;database=bd_Biblioteca_Musical;Integrated Security=True;TrustServerCertificate=true;";
            this.conexion.StringConexion = "server=localhost\\DEV;database=Biblioteca_Musical;Integrated Security=True;TrustServerCertificate=true;";
        }

        [TestMethod]
        public void Execute()
        {
            Insertar();
            Consultar();
            Actualizar();
            Borrar();
        }

        public void Insertar()
        {
            this.entidad = new Generos()
            {
                Nombre = "Género de prueba",
                Descripcion = "Descripción del género de prueba",
                popularidad = 1
            };

            this.conexion.Generos!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Generos!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "Género actualizado";
            this.entidad!.Descripcion = "Descripción actualizada";
            this.entidad!.popularidad = 2;

            var entry = this.conexion.Entry<Generos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Generos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
