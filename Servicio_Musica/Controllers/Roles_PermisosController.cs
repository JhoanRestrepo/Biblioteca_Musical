using Microsoft.AspNetCore.Mvc;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Implementaciones;
using Libreria.Nucleo;

namespace Servicio_Musica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")] // Ruta base: http://localhost:5034/Album/
    public class Roles_PermisosController : ControllerBase
    {
        // 1. Declarar las 3 interfaces de aplicación
        private IRoles_PermisosAplicacion IRoles_PermisosAplicacion;

        // 2. Inicializar las 3 dependencias en el constructor
        public Roles_PermisosController(IRoles_PermisosAplicacion IRoles_PermisosAplicacion)
        {

            this.IRoles_PermisosAplicacion = IRoles_PermisosAplicacion;
            
        }

        // ==========================================
        //                Roles_Permisos
        // ==========================================

        [HttpPost]
        public Roles_Permisos Insertar(Roles_Permisos entidad)
        {
            return this.IRoles_PermisosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public List<Roles_Permisos> Buscar(Roles_Permisos entidad)
        {
            return this.IRoles_PermisosAplicacion.Buscar(entidad);
        }
        
        [HttpPost]
        public IEnumerable<Roles_Permisos> Consultar()
        {
            return this.IRoles_PermisosAplicacion.Consultar();
        }

        [HttpPost]
        public Roles_Permisos Actualizar(Roles_Permisos entidad)
        {
            return this.IRoles_PermisosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Roles_Permisos Borrar(Roles_Permisos entidad)
        {
            return this.IRoles_PermisosAplicacion.Borrar(entidad);
        }

    }
}
