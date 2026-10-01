using Libreria.Entidades;
using Libreria.Implementaciones;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Pruebas_Unarias
{
    [TestClass]
    public sealed class ReproduccionesPruebas
    {
        private IConexion conexion;
        private Reproducciones? entidad = null;

        public ReproduccionesPruebas()
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
            this.entidad = new Reproducciones()
            {
                Usuario = 1,
                Cancion = 1,
                Fecha_Hora = DateTime.Now,
                Duracion = new TimeSpan(0, 3, 30)
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
