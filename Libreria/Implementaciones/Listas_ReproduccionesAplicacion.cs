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

            this.IConexion.Listas_Reproducciones!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Listas_Reproducciones Actualizar(Listas_Reproducciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            var entry = this.IConexion!.Entry<Listas_Reproducciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Listas_Reproducciones> Buscar(Listas_Reproducciones entidad)
        {
            return this.IConexion.Listas_Reproducciones!
                .Where(x => x.Cancion == entidad.Cancion)
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
    }
}
