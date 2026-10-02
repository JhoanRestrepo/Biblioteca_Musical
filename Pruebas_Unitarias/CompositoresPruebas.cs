using Libreria.Entidades;
using Libreria.Implementaciones;
using Libreria.Interfaces;
using Libreria.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace Pruebas_Unitarias
{
    [TestClass]
    public sealed class CompositoresPruebas
    {
        private IConexion conexion;
        private Compositores? entidad = null;

        public CompositoresPruebas()
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
            this.entidad = new Compositores()
            {
                Nombre = "Darío Gómez",
                Nacionalidad = "Español",
                Fecha_Nacimiento = new DateTime(1901, 11, 22)
            };

            this.conexion.Compositores!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Compositores!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Nacionalidad = "Colombiano";

            var entry = this.conexion.Entry<Compositores>(this.entidad);
            entry.State = EntityState.Modified;

            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Compositores!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
