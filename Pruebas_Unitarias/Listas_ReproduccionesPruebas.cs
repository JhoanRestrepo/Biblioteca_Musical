using Libreria.Entidades;
using Libreria.Implementaciones;
using Libreria.Interfaces;
using Libreria.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace Pruebas_Unitarias
{
    [TestClass]
    public sealed class Listas_ReproduccionesPruebas
    {
        private IConexion conexion;
        private Listas_Reproducciones? entidad = null;

        public Listas_ReproduccionesPruebas()
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
            this.entidad = new Listas_Reproducciones()
            {
                Nombre = "Lista de prueba",
                Fecha_Creacion = DateTime.Now,
                Privacidad = "Privada",
                Usuario = 1
            };

            this.conexion.Listas_Reproducciones!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Listas_Reproducciones!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "Lista Colaborativa";
            this.entidad.Privacidad = "Publica";

            var entry = this.conexion.Entry<Listas_Reproducciones>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Listas_Reproducciones!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}