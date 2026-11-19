using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Implementaciones
{
    public class CompositoresAplicacion : ICompositoresAplicacion
    {
        private IConexion IConexion;

        public CompositoresAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Compositores Insertar(Compositores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Nacionalidad) ||
                entidad.Fecha_Nacimiento == null)
                throw new Exception("Faltan valores");

            this.IConexion.Compositores!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Compositores Actualizar(Compositores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Nacionalidad) ||
                entidad.Fecha_Nacimiento == null)
                throw new Exception("Faltan valores");

            var entry = this.IConexion!.Entry<Compositores>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Compositores> Consultar()
        {
            return this.IConexion.Compositores!
                .Take(10)
                .ToList();
        }

        public List<Compositores> Buscar(Compositores entidad)
        {
            return this.IConexion.Compositores!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!) ||
                            x.Nacionalidad!.Contains(entidad.Nacionalidad!))
                .Take(10)
                .ToList();
        }

        public Compositores Borrar(Compositores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.Compositores!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Compositores entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Nacionalidad) ||
                string.IsNullOrEmpty(entidad.Fecha_Nacimiento.ToString());
        }
    }
}
