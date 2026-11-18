using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Implementaciones
{
    public class Canciones_IdiomasAplicacion : ICanciones_IdiomasAplicacion
    {
        private IConexion IConexion;

        public Canciones_IdiomasAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Canciones_Idiomas Insertar(Canciones_Idiomas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Fecha_Registro == null)
                entidad.Fecha_Registro = DateTime.Now;

            this.IConexion.Canciones_Idiomas!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Canciones_Idiomas Actualizar(Canciones_Idiomas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (entidad.Fecha_Registro == null)
                entidad.Fecha_Registro = DateTime.Now;

            var entry = this.IConexion!.Entry<Canciones_Idiomas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Canciones_Idiomas> Buscar(Canciones_Idiomas entidad)
        {
            return this.IConexion.Canciones_Idiomas!
                .Where(x => x.Cancion == entidad.Cancion)
                .Take(10)
                .ToList();
        }

        public List<Canciones_Idiomas> Consultar()
        {
            return this.IConexion.Canciones_Idiomas!
                .Take(10)
                .ToList();
        }

        public Canciones_Idiomas Borrar(Canciones_Idiomas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.Canciones_Idiomas!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
