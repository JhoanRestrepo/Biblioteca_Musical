using Libreria.Entidades;
using Libreria.Implementaciones;
using Libreria.Interfaces;
using Libreria.Nucleo;
using Microsoft.EntityFrameworkCore;

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

            private void Insertar()
            {
                this.entidad = new Idiomas()
                {
                    Nombre = "Portugués brasileño",
                    Codigo = "pt-br",
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
                this.entidad!.Nombre = "Italiano";
                this.entidad!.Codigo = "it";
                this.entidad!.Descripcion = "Idioma oficial de Italia";
                this.entidad!.Activo = true;

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
