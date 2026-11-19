using Microsoft.AspNetCore.Mvc;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Implementaciones;
using Libreria.Nucleo;

namespace Servicio_Musica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")] // Ruta base: http://localhost:5034/Album/
    public class PermisosController : ControllerBase
    {
        // 1. Declarar las 3 interfaces de aplicación
        private IPermisosAplicacion IPermisosAplicacion;

        // 2. Inicializar las 3 dependencias en el constructor
        public PermisosController(IPermisosAplicacion IPermisosAplicacion)
        {

            this.IPermisosAplicacion = IPermisosAplicacion;
            
        }

        // ==========================================
        //                Permisos
        // ==========================================

        [HttpPost]
        public Permisos Insertar(Permisos entidad)
        {
            return this.IPermisosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public List<Permisos> Buscar(Permisos entidad)
        {
            return this.IPermisosAplicacion.Buscar(entidad);
        }
        
        [HttpPost]
        public IEnumerable<Permisos> Consultar()
        {
            return this.IPermisosAplicacion.Consultar();
        }

        [HttpPost]
        public Permisos Actualizar(Permisos entidad)
        {
            return this.IPermisosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Permisos Borrar(Permisos entidad)
        {
            return this.IPermisosAplicacion.Borrar(entidad);
        }

    }
}
