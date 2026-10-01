using Libreria.Entidades;
using Libreria.Implementaciones;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Pruebas_Unitarias
{
    [TestClass]
    public sealed class Canciones_IdiomasPruebas
    {
        private IConexion conexion;
        private Canciones_Idiomas? entidad = null;

        public Canciones_IdiomasPruebas()
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
            this.entidad = new Canciones_Idiomas()
            {
                Cancion = 3,
                Idioma = 1,
                Idioma_Principal = "Italiano",
                Porcentaje = 100,
                Fecha_Registro = DateTime.Now,
            };

            this.conexion.Canciones_Idiomas!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Canciones_Idiomas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Cancion = 1;
            this.entidad.Idioma = 2;
            this.entidad.Idioma_Principal = "Portugues";
            this.entidad.Porcentaje = 50;


            var entry = this.conexion!.Entry<Canciones_Idiomas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Canciones_Idiomas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
