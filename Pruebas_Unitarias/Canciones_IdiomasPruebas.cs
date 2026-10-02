using Libreria.Entidades;
using Libreria.Implementaciones;
using Libreria.Interfaces;
using Libreria.Nucleo;
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
            this.entidad = new Canciones_Idiomas()
            {
                Cancion = 3,
                Idioma = 2,
                Porcentaje = 20,
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
            this.entidad!.Cancion = 2;
            this.entidad.Idioma = 1;
            this.entidad.Porcentaje = 25;


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
