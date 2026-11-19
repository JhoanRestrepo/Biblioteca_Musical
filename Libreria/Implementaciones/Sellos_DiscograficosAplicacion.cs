using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Implementaciones
{
    public class Sellos_DiscograficosAplicacion : ISellos_DiscograficosAplicacion
    {
        private IConexion IConexion;

        public Sellos_DiscograficosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Sellos_Discograficos Insertar(Sellos_Discograficos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Faltan valores");

            if (entidad.Fecha_Fundacion == null)
                entidad.Fecha_Fundacion = DateTime.Now;

            this.IConexion.Sellos_Discograficos!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Sellos_Discograficos Actualizar(Sellos_Discograficos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (Validar(entidad))
                throw new Exception("Faltan valores");

            if (entidad.Fecha_Fundacion == null)
                entidad.Fecha_Fundacion = DateTime.Now;

            var entry = this.IConexion!.Entry<Sellos_Discograficos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Sellos_Discograficos> Buscar(Sellos_Discograficos entidad)
        {
            return this.IConexion.Sellos_Discograficos!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .Take(10)
                .ToList();
        }

        public List<Sellos_Discograficos> Consultar()
        {
            return this.IConexion.Sellos_Discograficos!
                .ToList();
        }

        public Sellos_Discograficos Borrar(Sellos_Discograficos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.Sellos_Discograficos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Sellos_Discograficos entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Pais);
        }
    }
}