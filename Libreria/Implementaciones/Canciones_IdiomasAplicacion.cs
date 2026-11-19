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

            if (entidad.Cancion == 0 ||
                entidad.Idioma == 0 ||
                entidad.Porcentaje == null ||
                entidad.Fecha_Registro == null)
                throw new Exception("Faltan valores");

            if (!this.IConexion.Canciones!.Any(x => x.Id == entidad.Cancion))
                throw new Exception("La canción no existe");

            if (!this.IConexion.Idiomas!.Any(x => x.Id == entidad.Idioma))
                throw new Exception("El idioma no existe");

            this.IConexion.Canciones_Idiomas!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Canciones_Idiomas Actualizar(Canciones_Idiomas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (entidad.Cancion == 0 ||
                entidad.Idioma == 0 ||
                entidad.Porcentaje == null ||
                entidad.Fecha_Registro == null)
                throw new Exception("Faltan valores");

            var entry = this.IConexion!.Entry<Canciones_Idiomas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Canciones_Idiomas> Consultar()
        {
            return this.IConexion.Canciones_Idiomas!
                .Include(x => x._Cancion)
                .Include(x => x._Idioma)
                .Take(10)
                .ToList();
        }

        public List<Canciones_Idiomas> Buscar(Canciones_Idiomas entidad)
        {
            return this.IConexion.Canciones_Idiomas!
                .Include(x => x._Cancion)
                .Include(x => x._Idioma)
                .Where(x => x._Cancion!.Titulo!.Contains(entidad._Cancion!.Titulo!) ||
                            x._Idioma!.Nombre!.Contains(entidad._Idioma!.Nombre!))
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

        private bool Validar(Canciones_Idiomas entidad)
        {
            return string.IsNullOrEmpty(entidad.Cancion.ToString()) ||
                string.IsNullOrEmpty(entidad.Idioma.ToString()) ||
                string.IsNullOrEmpty(entidad.Porcentaje.ToString()) ||
                string.IsNullOrEmpty(entidad.Fecha_Registro.ToString());
        }
    }
}
