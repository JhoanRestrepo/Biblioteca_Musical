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
    public sealed class Sellos_DiscograficosPruebas
    {
        private IConexion conexion;
        private Sellos_Discograficos? entidad = null;

        public Sellos_DiscograficosPruebas()
        {
            this.conexion = new Conexion();
            //this.conexion.StringConexion = Datosgenerales.ObtenerStringConexion();
            this.conexion.StringConexion = "server=localhost;database=bd_Biblioteca_Musical;Integrated Security=True;TrustServerCertificate=true;";
            //this.conexion.StringConexion = "server=localhost\\DEV;database=Biblioteca_Musical;Integrated Security=True;TrustServerCertificate=true;";
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
            this.entidad = new Sellos_Discograficos()
            {
                Nombre = "Sello de Prueba",
                Pais = "Colombia",
                Fecha_Fundacion = new DateTime(2000, 1, 1),
                Sitio_Web = "https://www.selloprueba.com"
            };

            this.conexion.Sellos_Discograficos!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Sellos_Discograficos!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "Sello Actualizado";
            this.entidad.Pais = "España";
            this.entidad.Sitio_Web = "https://www.selloactualizado.com";

            var entry = this.conexion.Entry<Sellos_Discograficos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Sellos_Discograficos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
