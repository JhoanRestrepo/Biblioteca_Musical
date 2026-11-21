using Microsoft.AspNetCore.Mvc;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Implementaciones;
using Libreria.Nucleo;

namespace Servicio_Musica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")] // Ruta base: http://localhost:5034/Album/
    public class Usuarios_RolesController : ControllerBase
    {
        // 1. Declarar las 3 interfaces de aplicación
        private IUsuarios_RolesAplicacion IUsuarios_RolesAplicacion;

        // 2. Inicializar las 3 dependencias en el constructor
        public Usuarios_RolesController(IUsuarios_RolesAplicacion IUsuarios_RolesAplicacion)
        {

            this.IUsuarios_RolesAplicacion = IUsuarios_RolesAplicacion;
            
        }

        // ==========================================
        //                Usuarios_Roles
        // ==========================================

        [HttpPost]
        public Usuarios_Roles Insertar(Usuarios_Roles entidad)
        {
            return this.IUsuarios_RolesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public List<Usuarios_Roles> Buscar(Usuarios_Roles entidad)
        {
            return this.IUsuarios_RolesAplicacion.Buscar(entidad);
        }
        
        [HttpPost]
        public IEnumerable<Usuarios_Roles> Consultar()
        {
            return this.IUsuarios_RolesAplicacion.Consultar();
        }

        [HttpPost]
        public Usuarios_Roles Actualizar(Usuarios_Roles entidad)
        {
            return this.IUsuarios_RolesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Usuarios_Roles Borrar(Usuarios_Roles entidad)
        {
            return this.IUsuarios_RolesAplicacion.Borrar(entidad);
        }

    }
}
