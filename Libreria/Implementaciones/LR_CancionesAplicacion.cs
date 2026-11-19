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

            if (entidad._Lista_Reproduccion!.Id == 0 ||
                entidad._Cancion!.Id == 0)
                throw new Exception("Faltan valores");

            if (!this.IConexion.Listas_Reproducciones!.Any(x => x.Id == entidad.Lista_Reproduccion))
                throw new Exception("La lista de reproducción no existe");

            if (!this.IConexion.Canciones!.Any(x => x.Id == entidad.Cancion))
                throw new Exception("La canción no existe");

            this.IConexion.LR_Canciones!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public LR_Canciones Actualizar(LR_Canciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (entidad.Lista_Reproduccion == 0 ||
                entidad.Cancion == 0)
                throw new Exception("Faltan valores");

            var entry = this.IConexion!.Entry<LR_Canciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<LR_Canciones> Buscar(LR_Canciones entidad)
        {
            return this.IConexion.LR_Canciones!
                .Include(x => x._Lista_Reproduccion)
                .Include(x => x._Cancion)
                .Where(x => x._Lista_Reproduccion!.Nombre!.Contains(entidad._Lista_Reproduccion!.Nombre!) ||
                            x._Cancion!.Titulo!.Contains(entidad._Cancion!.Titulo!))
                .Take(10)
                .ToList();
        }

        public List<LR_Canciones> Consultar()
        {
            return this.IConexion.LR_Canciones!
                .Include(x => x._Lista_Reproduccion)
                .Include(x => x._Cancion)
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

        private bool Validar(LR_Canciones entidad)
        {
            return string.IsNullOrEmpty(entidad.Lista_Reproduccion.ToString()) ||
                string.IsNullOrEmpty(entidad.Cancion.ToString());
        }
    }
}
