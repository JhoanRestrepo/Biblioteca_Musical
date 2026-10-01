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
    public sealed class SuscripcionesPruebas
    {
        private IConexion conexion;
        private Suscripciones? entidad = null;

        public SuscripcionesPruebas()
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
            this.entidad = new Suscripciones()
            {
                Usuario = 1,
                Tipo_Plan = "Premium",
                Fecha_Inicio = DateTime.Now,
                Fecha_Fin = DateTime.Now.AddMonths(1)
            };

            this.conexion.Suscripciones!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Suscripciones!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Tipo_Plan = "Familiar";
            this.entidad.Fecha_Fin = DateTime.Now.AddMonths(3);

            var entry = this.conexion.Entry<Suscripciones>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Suscripciones!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
