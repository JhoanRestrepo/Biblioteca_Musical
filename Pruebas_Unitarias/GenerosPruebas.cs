using Libreria.Entidades;
using Libreria.Implementaciones;
using Libreria.Interfaces;
using Libreria.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace Pruebas_Unitarias
{
    [TestClass]
    public sealed class GenerosPruebas
    {
        private IConexion conexion;
        private Generos? entidad = null;

        public GenerosPruebas()
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
            this.entidad = new Generos()
            {
                Nombre = "Hip Hop",
                Descripcion = "El hip hop es un movimiento cultural y musical urbano que nació en el barrio del Bronx, en Nueva York, a principios de la década de 1970",
                popularidad = 92
            };

            this.conexion.Generos!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Generos!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "Metal";
            this.entidad!.Descripcion = "El metal es un género musical del rock que nació a finales de los años 60 y principios de los 70 en el Reino Unido y Estados Unidos.";
            this.entidad!.popularidad = 69;

            var entry = this.conexion.Entry<Generos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Generos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
