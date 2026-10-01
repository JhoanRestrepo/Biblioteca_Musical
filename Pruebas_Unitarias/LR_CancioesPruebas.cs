using Libreria.Entidades;
using Libreria.Implementaciones;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Pruebas_Unarias
{
    [TestClass]
    public sealed class LR_CancionesPruebas
    {
        private IConexion conexion;
        private LR_Canciones? entidad = null;

        public LR_CancionesPruebas()
        {
            this.conexion = new Conexion();
            //this.conexion.StringConexion = Datosgenerales.ObtenerStringConexion();
            //this.conexion.StringConexion = "server=localhost;database=bd_Biblioteca_Musical;Integrated Security=True;TrustServerCertificate=true;";
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
            this.entidad = new LR_Canciones()
            {
                Lista_Reproduccion = 1,
                Cancion = 1
            };

            this.conexion.LR_Canciones!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.LR_Canciones!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Cancion = 2;

            var entry = this.conexion.Entry<LR_Canciones>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.LR_Canciones!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
