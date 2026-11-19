using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.Implementaciones
{
    public class Canciones_CompositoresAplicacion : ICanciones_CompositoresAplicacion
    {
        private IConexion IConexion;

        public Canciones_CompositoresAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Canciones_Compositores Insertar(Canciones_Compositores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Faltan valores");

            this.IConexion.Canciones_Compositores!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Canciones_Compositores Actualizar(Canciones_Compositores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (Validar(entidad))
                throw new Exception("Faltan valores");

            var entry = this.IConexion!.Entry<Canciones_Compositores>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Canciones_Compositores> Buscar(Canciones_Compositores entidad)
        {
            return this.IConexion.Canciones_Compositores!
                .Where(x => x.Cancion == entidad.Cancion)
                .Take(10)
                .ToList();
        }

        public List<Canciones_Compositores> Consultar()
        {
            return this.IConexion.Canciones_Compositores!
                .Take(10)
                .ToList();
        }

        public Canciones_Compositores Borrar(Canciones_Compositores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.Canciones_Compositores!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Canciones_Compositores entidad)
        {
            return entidad.Cancion == 0 ||
                entidad.Compositor == 0;
        }
    }
}
