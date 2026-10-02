using Libreria.Entidades;
using Libreria.Implementaciones;
using Libreria.Interfaces;
using Libreria.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace Pruebas_Unitarias
{
    [TestClass]
    public sealed class Artistas_SellosPruebas
    {
        private IConexion conexion;
        private Artistas_Sellos? entidad = null;

        public Artistas_SellosPruebas()
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
            this.entidad = new Artistas_Sellos()
            {
                Artista = 3,
                Sello_Discografico = 1,
                Fecha_Inicio = DateTime.Now,
                Fecha_Fin = null,
                Contrato = "Contrato discográfico de prueba"
            };

            this.conexion.Artistas_Sellos!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Artistas_Sellos!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Contrato = "Contrato discográfico actualizado";
            this.entidad.Fecha_Fin = DateTime.Now;

            var entry = this.conexion.Entry<Artistas_Sellos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Artistas_Sellos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}