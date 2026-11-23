using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Implementaciones
{
    public class AuditoriasAplicacion : IAuditoriasAplicacion
    {
        private IConexion IConexion;

        public AuditoriasAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Auditorias Insertar(Auditorias entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (string.IsNullOrEmpty(entidad.Accion))
                throw new Exception("Faltan valores");

            entidad.Fecha = DateTime.Now;

            this.IConexion.Auditorias!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Auditorias Actualizar(Auditorias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (string.IsNullOrEmpty(entidad.Accion))
                throw new Exception("Faltan valores");

            entidad.Fecha = DateTime.Now;

            var entry = this.IConexion!.Entry<Auditorias>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Auditorias> Buscar(Auditorias entidad)
        {
            return this.IConexion.Auditorias!
                .Include(x => x._Usuario)
                .Where(x => x.Accion!.Contains(entidad.Accion!))
                .Take(10)
                .ToList();
        }

        public List<Auditorias> Consultar()
        {
            return this.IConexion.Auditorias!
                .Include(x => x._Usuario)
                .Take(10)
                .ToList();
        }

        public Auditorias Borrar(Auditorias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.Auditorias!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Auditorias entidad)
        {
            return string.IsNullOrEmpty(entidad.Accion) ||
                string.IsNullOrEmpty(entidad.Fecha.ToString());
        }
    }
}
