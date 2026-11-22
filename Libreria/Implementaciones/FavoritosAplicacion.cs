using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Implementaciones
{
    public class FavoritosAplicacion : IFavoritosAplicacion
    {
        private IConexion IConexion;

        public FavoritosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Favoritos Insertar(Favoritos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Usuario == 0 ||
                entidad.Fecha_Marcado == null)
                throw new Exception("Faltan valores");

            if (!this.IConexion.Usuarios!.Any(x => x.Id == entidad.Usuario))
                throw new Exception("El usuario no existe");

            this.IConexion.Favoritos!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Favoritos Actualizar(Favoritos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (entidad.Usuario == 0 ||
                entidad.Fecha_Marcado == null)
                throw new Exception("Faltan valores");

            var entry = this.IConexion!.Entry<Favoritos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Favoritos> Consultar()
        {
            return this.IConexion.Favoritos!
                .Include(x => x._Usuario)
                .Take(10)
                .ToList();
        }

        public List<Favoritos> Buscar(Favoritos entidad)
        {
            return this.IConexion.Favoritos!
                .Take(10)
                .ToList();
        }
        public Favoritos Borrar(Favoritos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.Favoritos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Favoritos entidad)
        {
            return string.IsNullOrEmpty(entidad.Usuario.ToString()) ||
                string.IsNullOrEmpty(entidad.Fecha_Marcado.ToString());
        }
    }
}
