using Libreria.Entidades;
using Libreria.Implementaciones;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pruebas_Unitarias
{
    namespace Pruebas_Unitarias
    {
        [TestClass]
        public sealed class IdiomasPruebas
        {
            private IConexion conexion;
            private Idiomas? entidad = null;

            public IdiomasPruebas()
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

            private void Insertar()
            {
                this.entidad = new Idiomas()
                {
                    Nombre = "Portugués brasileño",
                    Codigo = "pt-BR",
                    Descripcion = "Portugués hablado en Brasil",
                    Activo = true
                };

                this.conexion.Idiomas!.Add(this.entidad);
                this.conexion.SaveChanges();
            }

            private void Consultar()
            {
                var lista = this.conexion.Idiomas!.ToList();

                if (lista.Count <= 0)
                    throw new Exception("Lista vacía");
            }

            private void Actualizar()
            {
                this.entidad!.Descripcion = "Idioma oficial de Brasil";

                var entry = this.conexion.Entry<Idiomas>(this.entidad);
                entry.State = EntityState.Modified;
                this.conexion.SaveChanges();
            }

            private void Borrar()
            {
                this.conexion.Idiomas!.Remove(this.entidad!);
                this.conexion.SaveChanges();
            }
        }
    }
}
