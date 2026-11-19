using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Implementaciones
{
    public class SuscripcionesAplicacion : ISuscripcionesAplicacion
    {
        private IConexion IConexion;

        public SuscripcionesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Suscripciones Insertar(Suscripciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (entidad._Usuario!.Id == 0 ||
                string.IsNullOrEmpty(entidad.Tipo_Plan) ||
                entidad.Fecha_Inicio == null ||
                entidad.Fecha_Fin == null)
                throw new Exception("Faltan valores");

            if (!this.IConexion.Usuarios!.Any(x => x.Id == entidad.Usuario))
                throw new Exception("El usuario no existe");

            this.IConexion.Suscripciones!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Suscripciones Actualizar(Suscripciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (entidad.Usuario == 0 ||
                string.IsNullOrEmpty(entidad.Tipo_Plan) ||
                entidad.Fecha_Inicio == null ||
                entidad.Fecha_Fin == null)
                throw new Exception("Faltan valores");

            var entry = this.IConexion!.Entry<Suscripciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Suscripciones> Buscar(Suscripciones entidad)
        {
            return this.IConexion.Suscripciones!
                .Include(x => x._Usuario)
                .Where(x => x.Tipo_Plan!.Contains(entidad.Tipo_Plan!))
                .Take(10)
                .ToList();
        }

        public List<Suscripciones> Consultar()
        {
            return this.IConexion.Suscripciones!
                .Include(x => x._Usuario)
                .Take(10)
                .ToList();
        }

        public Suscripciones Borrar(Suscripciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.Suscripciones!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Suscripciones entidad)
        {
            return string.IsNullOrEmpty(entidad.Usuario.ToString()) ||
                string.IsNullOrEmpty(entidad.Tipo_Plan) ||
                string.IsNullOrEmpty(entidad.Fecha_Inicio.ToString()) ||
                string.IsNullOrEmpty(entidad.Fecha_Fin.ToString());
        }
    }
}
