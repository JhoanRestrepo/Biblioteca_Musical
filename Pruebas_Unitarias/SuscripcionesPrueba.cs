using Libreria.Entidades;
using Libreria.Implementaciones;
using Libreria.Interfaces;
using Libreria.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace Pruebas_Unitarias
{
    [TestClass]
    public sealed class SuscripcionesPruebas
    {
        private IConexion conexion;
        private Suscripciones? entidad = null;

        public SuscripcionesPruebas()
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
            this.entidad = new Suscripciones()
            {
                Usuario = 2,
                Tipo_Plan = "Premium",
                Fecha_Inicio = DateTime.Now,
                Fecha_Fin = DateTime.Now.AddMonths(1)
            };

            this.conexion.Suscripciones!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Suscripciones!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Tipo_Plan = "Estudiante";
            this.entidad.Fecha_Fin = DateTime.Now.AddMonths(6);

            var entry = this.conexion.Entry<Suscripciones>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Suscripciones!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
