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
                Nombre = "Alcolirykoz",
                Nacionalidad = "Colombia",
                Fecha_Inicio = DateTime.Now,
                Biografia = "AlcolirykoZ es un grupo de rap colombiano originario del barrio Aranjuez en Medellín, Antioquia. Formado en 1999"
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
            this.entidad!.Nombre = "Juanes";
            this.entidad!.Biografia = "Juan Esteban Aristizábal Vásquez, conocido artísticamente como Juanes, es un cantante, compositor y guitarrista colombiano de música pop latino y rock en español. Nació el 9 de agosto de 1972 en Medellín, Colombia. Juanes ha sido reconocido por su estilo musical que combina elementos del rock, pop y música tradicional colombiana, y ha ganado numerosos premios a lo largo de su carrera, incluyendo varios premios Grammy Latinos y Grammy Awards.";

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
