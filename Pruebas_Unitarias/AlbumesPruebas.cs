using Libreria.Entidades;
using Libreria.Implementaciones;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Pruebas_Unitarias
{
    [TestClass]
    public sealed class AlbumesPruebas
    {
        private IConexion conexion;
        private Albumes? entidad = null;

        public AlbumesPruebas()
        {
            this.conexion = new Conexion();
            //this.conexion.StringConexion = Datosgenerales.ObtenerStringConexion();
            this.conexion.StringConexion = "server=localhost;database=BibliotecaMusical;Integrated Security=True;TrustServerCertificate=true;";
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
            this.entidad = new Albumes()
            {
                Titulo = "Servicios Ambulatorioz",
                Fecha_Lanzamiento = DateTime.Now,
                Portada = "Servicios Ambulatorioz.JPG",
            };
            this.conexion.Albumes!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Albumes!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Titulo = "Aranjuez";
            this.entidad!.Portada = "Aranjuez.JPG";

            var entry = this.conexion!.Entry<Albumes>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Albumes!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
