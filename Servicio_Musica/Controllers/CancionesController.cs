using Microsoft.AspNetCore.Mvc;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Implementaciones;
using Libreria.Nucleo;

namespace Servicio_Musica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")] // Ruta base: http://localhost:5034/Album/
    public class CancionesController : ControllerBase
    {
        // 1. Declarar las 3 interfaces de aplicación
        private ICancionesAplicacion ICancionesAplicacion;

        // 2. Inicializar las 3 dependencias en el constructor
        public CancionesController(ICancionesAplicacion ICancionesAplicacion)
        {

            this.ICancionesAplicacion = ICancionesAplicacion;
            
        }

        // ==========================================
        //                Canciones
        // ==========================================

        [HttpPost]
        public Canciones Insertar(Canciones entidad)
        {
            return this.ICancionesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public List<Canciones> Buscar(Canciones entidad)
        {
            return this.ICancionesAplicacion.Buscar(entidad);
        }
        
        [HttpPost]
        public IEnumerable<Canciones> Consultar()
        {
            return this.ICancionesAplicacion.Consultar();
        }

        [HttpPost]
        public Canciones Actualizar(Canciones entidad)
        {
            return this.ICancionesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Canciones Borrar(Canciones entidad)
        {
            return this.ICancionesAplicacion.Borrar(entidad);
        }

    }
}
