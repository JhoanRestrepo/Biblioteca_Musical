using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Implementaciones
{
    public class Listas_CancionesAplicacion : IListas_CancionesAplicacion
    {
        private IConexion IConexion;

        public Listas_CancionesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Listas_Canciones Insertar(Listas_Canciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.IConexion.Listas_Canciones!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Listas_Canciones Actualizar(Listas_Canciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            var entry = this.IConexion!.Entry<Listas_Canciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Listas_Canciones> Buscar(Listas_Canciones entidad)
        {
            return this.IConexion.Listas_Canciones!
                .Where(x => x.Cancion == entidad.Cancion)
                .Take(10)
                .ToList();
        }

        public List<Listas_Canciones> Consultar()
        {
            return this.IConexion.Listas_Canciones!
                .Take(10)
                .ToList();
        }

        public Listas_Canciones Borrar(Listas_Canciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.Listas_Canciones!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
