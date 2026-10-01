using Libreria.Entidades;
using Libreria.Implementaciones;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Pruebas_Unitarias
{
    [TestClass]
    public sealed class Canciones_CompositoresPruebas
    {
        private IConexion conexion;
        private Canciones_Compositores? entidad = null;

        public Canciones_CompositoresPruebas()
        {
            this.conexion = new Conexion();
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
            this.entidad = new Canciones_Compositores()
            {
                Cancion = 3,
                Compositor = 1,
                Porcentaje_Autoria = 50,
                Fecha_Registro = DateTime.Now,
            };

            this.conexion.Canciones_Compositores!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Canciones_Compositores!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Cancion = 1;
            this.entidad.Compositor = 2;
            this.entidad.Porcentaje_Autoria = 85;
            this.entidad.Fecha_Registro = DateTime.Now;

            var entry = this.conexion!.Entry<Canciones_Compositores>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Canciones_Compositores!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
