using Libreria.Entidades;
using Libreria.Implementaciones;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Pruebas_Unitarias
{
    [TestClass]
    public sealed class Listas_CancionesPruebas
    {
        private IConexion conexion;
        private Listas_Canciones? entidad = null;

        public Listas_CancionesPruebas()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion =
                "server=localhost\\DEV;database=bd_Biblioteca_Musical;Integrated Security=True;TrustServerCertificate=true;";
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
            this.entidad = new Listas_Canciones()
            {
                Cancion = 1,
                Posicion = 1,
                Fecha_Agregada = DateTime.Now,
                Favorita = 1
            };

            this.conexion.Listas_Canciones!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Listas_Canciones!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Posicion = 2;
            this.entidad.Fecha_Agregada = DateTime.Now;

            var entry = this.conexion.Entry<Listas_Canciones>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Listas_Canciones!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
