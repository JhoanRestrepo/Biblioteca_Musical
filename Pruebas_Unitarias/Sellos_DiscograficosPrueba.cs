using Libreria.Entidades;
using Libreria.Implementaciones;
using Libreria.Interfaces;
using Libreria.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace Pruebas_Unitarias
{
    [TestClass]
    public sealed class Sellos_DiscograficosPruebas
    {
        private IConexion conexion;
        private Sellos_Discograficos? entidad = null;

        public Sellos_DiscograficosPruebas()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = Datos_Generales.ObtenerStringConexion();
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
                Nombre = "Death Row Records",
                Pais = "Estados Unidos",
                Fecha_Fundacion = new DateTime(1991, 7, 1),
                Sitio_Web = "https://www.deathrowrecords.com"
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
            this.entidad!.Nombre = "EMI Records";
            this.entidad.Pais = "Reino Unido";
            this.entidad.Fecha_Fundacion = new DateTime(1973, 1, 1);
            this.entidad.Sitio_Web = "https://www.emirecords.com";

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
