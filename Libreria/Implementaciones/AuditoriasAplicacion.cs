using Libreria.Entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Implementaciones
{
    public class AuditoriasAplicacion : IAuditoriaAplicacion
    {
        private IConexion IConexion;

        public AuditoriasAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Auditoria Insertar(Auditoria entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (string.IsNullOrEmpty(entidad.Titulo) ||
                string.IsNullOrEmpty(entidad.Portada))
                throw new Exception("Faltan valores");

            if (entidad.Fecha_Lanzamiento == null)
                entidad.Fecha_Lanzamiento = DateTime.Now;

            this.IConexion.Auditoria!.Add(entidad!);
            this.IConexion.SaveChanges();

            return entidad;
        }

        public Auditoria Actualizar(Auditoria entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            if (string.IsNullOrEmpty(entidad.Titulo) ||
                string.IsNullOrEmpty(entidad.Portada))
                throw new Exception("Faltan valores");

            if (entidad.Fecha_Lanzamiento == null)
                entidad.Fecha_Lanzamiento = DateTime.Now;

            var entry = this.IConexion!.Entry<Auditoria>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public List<Auditoria> Buscar(Auditoria entidad)
        {
            return this.IConexion.Auditoria!
                .Where(x => x.Titulo!.Contains(entidad.Titulo!))
                .Take(10)
                .ToList();
        }

        public List<Auditoria> Consultar()
        {
            return this.IConexion.Auditoria!
                .Take(10)
                .ToList();
        }

        public Auditoria Borrar(Auditoria entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se guardo");

            this.IConexion.Auditoria!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Auditoria entidad)
        {
            return string.IsNullOrEmpty(entidad.Titulo) ||
                string.IsNullOrEmpty(entidad.Portada) ||
                entidad.Fecha_Lanzamiento == null;
        }

        public List<Auditoria_Artistas> Buscar(AuditoriasAplicacion album)
        {
            throw new NotImplementedException();
        }
    }
}