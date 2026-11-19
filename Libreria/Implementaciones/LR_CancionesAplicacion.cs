using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Implementaciones
{
    public class LR_CancionesAplicacion : ILR_CancionesAplicacion
    {
        private IConexion IConexion;

        public LR_CancionesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public LR_Canciones Insertar(LR_Canciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (string.IsNullOrEmpty(entidad.Titulo))
                throw new Exception("Faltan valores");

            this.IConexion.LR_Canciones!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public LR_Canciones Actualizar(LR_Canciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (string.IsNullOrEmpty(entidad.Titulo))
                throw new Exception("Faltan valores");

            var entry = this.IConexion!.Entry<LR_Canciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<LR_Canciones> Buscar(LR_Canciones entidad)
        {
            return this.IConexion.LR_Canciones!
                .Include(x => x._Album)
                .Where(x => x.Titulo!.Contains(entidad.Titulo!))
                .Take(10)
                .ToList();
        }

        public List<LR_Canciones> Consultar()
        {
            return this.IConexion.LR_Canciones!
                .Include(x => x._Album)
                .Take(10)
                .ToList();
        }

        public LR_Canciones Borrar(LR_Canciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.LR_Canciones!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
