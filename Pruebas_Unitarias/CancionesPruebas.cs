using Libreria.Entidades;
using Libreria.Implementaciones;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Pruebas_Unitarias
{
    [TestClass]
    public sealed class CancionesPruebas
    {
        private IConexion conexion;
        private Canciones? entidad = null;

        public CancionesPruebas()
        {
            this.conexion = new Conexion();
            //this.conexion.StringConexion = Datosgenerales.ObtenerStringConexion();
            this.conexion.StringConexion = "server=localhost;database=bd_Biblioteca_Musical;Integrated Security=True;TrustServerCertificate=true;";
            //this.conexion.StringConexion = "server=localhost\\DEV;database=bd_Biblioteca_Musical;Integrated Security=True;TrustServerCertificate=true;";
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
            this.entidad = new Canciones()
            {
                Titulo = "El Malo de la Película",
                Duracion = new TimeSpan(0, 3, 47),
                Numero_Pista = 11,
                Album = 2
            };
            this.conexion.Canciones!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Canciones!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Titulo = "La Funa";
            this.entidad!.Duracion = new TimeSpan(0, 3, 31);
            this.entidad!.Numero_Pista = 1;
            this.entidad!.Album = 2;

            var entry = this.conexion!.Entry<Canciones>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Canciones!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
