using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Implementaciones
{
    public class Listas_ReproduccionesAplicacion : IListas_ReproduccionesAplicacion
    {
        private IConexion IConexion;

        public Listas_ReproduccionesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Listas_Reproducciones Insertar(Listas_Reproducciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (string.IsNullOrEmpty(entidad.Nombre) ||
                entidad.Fecha_Creacion == null ||
                string.IsNullOrEmpty(entidad.Privacidad) ||
                entidad.Usuario == 0)
                throw new Exception("Faltan valores");

            if (!this.IConexion.Usuarios!.Any(x => x.Id == entidad.Usuario))
                throw new Exception("El usuario no existe");

            this.IConexion.Listas_Reproducciones!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Listas_Reproducciones Actualizar(Listas_Reproducciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (string.IsNullOrEmpty(entidad.Nombre) ||
                entidad.Fecha_Creacion == null ||
                string.IsNullOrEmpty(entidad.Privacidad) ||
                entidad.Usuario == 0)
                throw new Exception("Faltan valores");

            var entry = this.IConexion!.Entry<Listas_Reproducciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Listas_Reproducciones> Buscar(Listas_Reproducciones entidad)
        {
            return this.IConexion.Listas_Reproducciones!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .Take(10)
                .ToList();
        }

        public List<Listas_Reproducciones> Consultar()
        {
            return this.IConexion.Listas_Reproducciones!
                .Take(10)
                .ToList();
        }

        public Listas_Reproducciones Borrar(Listas_Reproducciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.Listas_Reproducciones!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Listas_Reproducciones entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Fecha_Creacion.ToString()) ||
                string.IsNullOrEmpty(entidad.Privacidad) ||
                string.IsNullOrEmpty(entidad.Usuario.ToString());
        }
    }
}
