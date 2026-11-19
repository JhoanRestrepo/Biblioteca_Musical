using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Implementaciones
{
    public class ReproduccionesAplicacion : IReproduccionesAplicacion
    {
        private IConexion IConexion;

        public ReproduccionesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Reproducciones Insertar(Reproducciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (entidad._Usuario!.Id == 0 ||
                entidad._Cancion!.Id == 0 ||
                entidad.Fecha_Hora == null ||
                entidad.Duracion == null)
                throw new Exception("Faltan valores");

            if (!this.IConexion.Usuarios!.Any(x => x.Id == entidad.Usuario))
                throw new Exception("El usuario no existe");

            if (!this.IConexion.Canciones!.Any(x => x.Id == entidad.Cancion))
                throw new Exception("La canción no existe");

            this.IConexion.Reproducciones!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Reproducciones Actualizar(Reproducciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (entidad.Usuario == 0 ||
                entidad.Cancion == 0 ||
                entidad.Fecha_Hora == null ||
                entidad.Duracion == null)
                throw new Exception("Faltan valores");

            var entry = this.IConexion!.Entry<Reproducciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Reproducciones> Consultar()
        {
            return this.IConexion.Reproducciones!
                .Include(x => x._Usuario)
                .Include(x => x._Cancion)
                .Take(10)
                .ToList();
        }

        public List<Reproducciones> Buscar(Reproducciones entidad)
        {
            return this.IConexion.Reproducciones!
                .Include(x => x._Usuario)
                .Include(x => x._Cancion)
                .Where(x => x._Usuario!.Nombre!.Contains(entidad._Usuario!.Nombre!) ||
                            x._Cancion!.Titulo!.Contains(entidad._Cancion!.Titulo!))
                .Take(10)
                .ToList();
        }

        public Reproducciones Borrar(Reproducciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.Reproducciones!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Reproducciones entidad)
        {
            return string.IsNullOrEmpty(entidad.Usuario.ToString()) ||
                string.IsNullOrEmpty(entidad.Cancion.ToString()) ||
                string.IsNullOrEmpty(entidad.Fecha_Hora.ToString()) ||
                string.IsNullOrEmpty(entidad.Duracion.ToString());
        }
    }
}
