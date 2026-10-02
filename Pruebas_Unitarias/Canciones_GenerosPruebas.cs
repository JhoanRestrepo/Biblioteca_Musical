using Libreria.Entidades;
using Libreria.Implementaciones;
using Libreria.Interfaces;
using Libreria.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace Pruebas_Unitarias
{
    [TestClass]
    public sealed class Canciones_GenerosPruebas
    {
        private IConexion conexion;
        private Canciones_Generos? entidad = null;

        public Canciones_GenerosPruebas()
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
            this.entidad = new Canciones_Generos()
            {
                Cancion = 3,
                Genero = 1,
                Principal = true,
                
            };

            this.conexion.Canciones_Generos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Canciones_Generos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Cancion = 1;
            this.entidad.Genero = 2;
            this.entidad.Principal = false;


            var entry = this.conexion!.Entry<Canciones_Generos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Canciones_Generos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
