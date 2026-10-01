using Libreria.Entidades;
using Libreria.Implementaciones;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pruebas_Unarias
{
    [TestClass]
    public sealed class UsuariosPruebas
    {
        private IConexion conexion;
        private Usuarios? entidad = null;

        public UsuariosPruebas()
        {
            this.conexion = new Conexion();
            //this.conexion.StringConexion = Datosgenerales.ObtenerStringConexion();
            //this.conexion.StringConexion = "server=localhost;database=bd_Biblioteca_Musical;Integrated Security=True;TrustServerCertificate=true;";
            this.conexion.StringConexion = "server=localhost\\DEV;database=Biblioteca_Musical;Integrated Security=True;TrustServerCertificate=true;";
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
                Nombre = "Usuario",
                Apellido = "Prueba",
                Correo = "usuario.prueba@gmail.com",
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
            this.entidad!.Nombre = "Usuario Actualizado";
            this.entidad.Apellido = "Prueba Actualizada";
            this.entidad.Correo = "usuario.actualizado@gmail.com";

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
