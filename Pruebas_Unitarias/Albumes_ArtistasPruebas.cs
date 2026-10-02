using Libreria.Entidades;
using Libreria.Implementaciones;
using Libreria.Interfaces;
using Libreria.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace Pruebas_Unitarias
{
    [TestClass]
    public sealed class Albumes_ArtistasPruebas
    {
        private IConexion conexion;
        private Albumes_Artistas? entidad = null;

        public Albumes_ArtistasPruebas()
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
            this.entidad = new Albumes_Artistas()
            {
                Album = 1,
                Artista = 1,
            };
            this.conexion.Albumes_Artistas!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Albumes_Artistas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Album = 2;

            var entry = this.conexion!.Entry<Albumes_Artistas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Albumes_Artistas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
