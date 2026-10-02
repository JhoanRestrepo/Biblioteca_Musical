using Libreria.Entidades;
using Libreria.Implementaciones;
using Libreria.Interfaces;
using Libreria.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace Pruebas_Unitarias
{
    [TestClass]
    public sealed class UsuariosPruebas
    {
        private IConexion conexion;
        private Usuarios? entidad = null;

        public UsuariosPruebas()
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
            this.entidad = new Usuarios()
            {
                Nombre = "Henry",
                Apellido = "Carrasco",
                Correo = "henry278@gmail.com",
                Fecha_Registro = DateTime.Now
            };

            this.conexion.Usuarios!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Usuarios!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "Luisa";
            this.entidad.Apellido = "Rodriguez";
            this.entidad.Correo = "rodriguezl445@gmail.com";
            this.entidad.Fecha_Registro = DateTime.Now.AddDays(+10);

            var entry = this.conexion.Entry<Usuarios>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Usuarios!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
