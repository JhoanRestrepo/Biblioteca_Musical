using Microsoft.AspNetCore.Mvc;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Implementaciones;
using Libreria.Nucleo;

namespace Servicio_Musica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")] // Ruta base: http://localhost:5034/Album/
    public class UsuariosController : ControllerBase
    {
        // 1. Declarar las 3 interfaces de aplicación
        private IUsuariosAplicacion IUsuariosAplicacion;

        // 2. Inicializar las 3 dependencias en el constructor
        public UsuariosController(IUsuariosAplicacion IUsuariosAplicacion)
        {

            this.IUsuariosAplicacion = IUsuariosAplicacion;
            
        }

        // ==========================================
        //                Usuarios
        // ==========================================

        [HttpPost]
        public Usuarios Insertar(Usuarios entidad)
        {
            return this.IUsuariosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public List<Usuarios> Buscar(Usuarios entidad)
        {
            return this.IUsuariosAplicacion.Buscar(entidad);
        }
        
        [HttpPost]
        public IEnumerable<Usuarios> Consultar()
        {
            return this.IUsuariosAplicacion.Consultar();
        }

        [HttpPost]
        public Usuarios Actualizar(Usuarios entidad)
        {
            return this.IUsuariosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Usuarios Borrar(Usuarios entidad)
        {
            return this.IUsuariosAplicacion.Borrar(entidad);
        }

    }
}
