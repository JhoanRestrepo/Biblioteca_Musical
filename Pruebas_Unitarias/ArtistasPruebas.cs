using Libreria.Entidades;
using Libreria.Implementaciones;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Pruebas_Unitarias
{
    [TestClass]
    public sealed class ArtistasPruebas
    {
        private IConexion conexion;
        private Artistas? entidad = null;

        public ArtistasPruebas()
        {
            this.conexion = new Conexion();
            //this.conexion.StringConexion = Datosgenerales.ObtenerStringConexion();
            this.conexion.StringConexion = "server=localhost\\DEV;database=bd_Biblioteca_Musical;Integrated Security=True;TrustServerCertificate=true;";
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
            this.entidad = new Artistas()
            {
                Nombre = "Test",
                Nacionalidad = "Test",
                Fecha_Inicio = DateTime.Now,
                Biografia = "Test"
            };
            this.conexion.Artistas!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Artistas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "Test.2";

            var entry = this.conexion!.Entry<Artistas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Artistas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
