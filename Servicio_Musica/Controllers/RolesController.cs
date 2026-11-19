using Microsoft.AspNetCore.Mvc;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Implementaciones;
using Libreria.Nucleo;

namespace Servicio_Musica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")] // Ruta base: http://localhost:5034/Album/
    public class RolesController : ControllerBase
    {
        // 1. Declarar las 3 interfaces de aplicación
        private IRolesAplicacion IRolesAplicacion;

        // 2. Inicializar las 3 dependencias en el constructor
        public RolesController(IRolesAplicacion IRolesAplicacion)
        {

            this.IRolesAplicacion = IRolesAplicacion;
            
        }

        // ==========================================
        //                Roles
        // ==========================================

        [HttpPost]
        public Roles Insertar(Roles entidad)
        {
            return this.IRolesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public List<Roles> Buscar(Roles entidad)
        {
            return this.IRolesAplicacion.Buscar(entidad);
        }
        
        [HttpPost]
        public IEnumerable<Roles> Consultar()
        {
            return this.IRolesAplicacion.Consultar();
        }

        [HttpPost]
        public Roles Actualizar(Roles entidad)
        {
            return this.IRolesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Roles Borrar(Roles entidad)
        {
            return this.IRolesAplicacion.Borrar(entidad);
        }

    }
}
