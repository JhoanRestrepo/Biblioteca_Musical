using Microsoft.AspNetCore.Mvc;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Implementaciones;
using Libreria.Nucleo;

namespace Servicio_Musica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuditoriasController : ControllerBase
    {
        // 1. Declarar la interfaz de aplicación
        private IAuditoriasAplicacion IAuditoriasAplicacion;

        // 2. Inicializar la dependencia en el constructor
        public AuditoriasController(IAuditoriasAplicacion IAuditoriasAplicacion)
        {

            this.IAuditoriasAplicacion = IAuditoriasAplicacion;
            
        }

        // ==========================================
        //              Auditorias
        // ==========================================

        [HttpPost]
        public Auditorias Insertar(Auditorias entidad)
        {
            return this.IAuditoriasAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public IEnumerable<Auditorias> Consultar()
        {
            return this.IAuditoriasAplicacion.Consultar();
        }

        [HttpPost]
        public List<Auditorias> Buscar(Auditorias entidad)
        {
            return this.IAuditoriasAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Auditorias Actualizar(Auditorias entidad)
        {
            return this.IAuditoriasAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Auditorias Borrar(Auditorias entidad)
        {
            return this.IAuditoriasAplicacion.Borrar(entidad);
        }

    }
}
