using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Implementaciones
{
    public class UsuariosAplicacion : IUsuariosAplicacion
    {
        private IConexion IConexion;

        public UsuariosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Usuarios Insertar(Usuarios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Apellido) ||
                string.IsNullOrEmpty(entidad.Correo) ||
                string.IsNullOrEmpty(entidad.Fecha_Registro)) 
               throw new Exception("Faltan valores");

            this.IConexion.Usuarios!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Usuarios Actualizar(Usuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (string.IsNullOrEmpty(entidad.Nombre) ||
                 string.IsNullOrEmpty(entidad.Apellido) ||
                 string.IsNullOrEmpty(entidad.Correo) ||
                 string.IsNullOrEmpty(entidad.Fecha_Registro))
                throw new Exception("Faltan valores");

            var entry = this.IConexion!.Entry<Usuarios>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Usuarios> Buscar(Usuarios entidad)
        {
            return this.IConexion.Usuarios!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .Take(10)
                .ToList();
        }

        public List<Usuarios> Consultar()
        {
            return this.IConexion.Usuarios!
                .Take(10)
                .ToList();
        }

        public Usuarios Borrar(Usuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.Usuarios!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
