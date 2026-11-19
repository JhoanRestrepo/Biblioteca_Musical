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

            if (string.IsNullOrEmpty(entidad.Usuario) ||
                string.IsNullOrEmpty(entidad.Tipo_Plan) ||
                string.IsNullOrEmpty(entidad.Fecha_Inicio) ||
                string.IsNullOrEmpty(entidad.Fecha_Fin))
                throw new Exception("Faltan valores");

            this.IConexion.Suscripciones!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Suscripciones Actualizar(Suscripciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (string.IsNullOrEmpty(entidad.Usuario) ||
                string.IsNullOrEmpty(entidad.Tipo_Plan) ||
                string.IsNullOrEmpty(entidad.Fecha_Inicio) ||
                string.IsNullOrEmpty(entidad.Fecha_Fin))

                throw new Exception("Faltan valores");

            var entry = this.IConexion!.Entry<Suscripciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Suscripciones> Buscar(Suscripciones entidad)
        {
            return this.IConexion.Suscripciones!
                .Where(x => x.Usuario!.Contains(entidad.Usuario!))
                .Take(10)
                .ToList();
        }

        public List<Suscripciones> Consultar()
        {
            return this.IConexion.Suscripciones!
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
    }
}
