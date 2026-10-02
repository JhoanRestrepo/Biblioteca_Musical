using Libreria.Entidades;
using Libreria.Implementaciones;
using Libreria.Interfaces;
using Libreria.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace Pruebas_Unitarias
{
    [TestClass]
    public sealed class ReproduccionesPruebas
    {
        private IConexion conexion;
        private Reproducciones? entidad = null;

        public ReproduccionesPruebas()
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
            this.entidad = new Reproducciones()
            {
                Usuario = 3,
                Cancion = 2,
                Fecha_Hora = DateTime.Now,
                Duracion = new TimeSpan(0, 5, 17)
            };

            this.conexion.Reproducciones!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Reproducciones!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Cancion = 1;
            this.entidad!.Fecha_Hora = DateTime.Now.AddHours(1);
            this.entidad!.Duracion = new TimeSpan(0, 4, 15);

            var entry = this.conexion.Entry<Reproducciones>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Reproducciones!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
