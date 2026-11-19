using Microsoft.AspNetCore.Mvc;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Implementaciones;
using Libreria.Nucleo;

namespace Servicio_Musica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")] // Ruta base: http://localhost:5034/Album/
    public class SuscripcionesController : ControllerBase
    {
        // 1. Declarar las 3 interfaces de aplicación
        private ISuscripcionesAplicacion ISuscripcionesAplicacion;

        // 2. Inicializar las 3 dependencias en el constructor
        public SuscripcionesController(ISuscripcionesAplicacion ISuscripcionesAplicacion)
        {

            this.ISuscripcionesAplicacion = ISuscripcionesAplicacion;
            
        }

        // ==========================================
        //                Suscripciones
        // ==========================================

        [HttpPost]
        public Suscripciones Insertar(Suscripciones entidad)
        {
            return this.ISuscripcionesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public List<Suscripciones> Buscar(Suscripciones entidad)
        {
            return this.ISuscripcionesAplicacion.Buscar(entidad);
        }
        
        [HttpPost]
        public IEnumerable<Suscripciones> Consultar()
        {
            return this.ISuscripcionesAplicacion.Consultar();
        }

        [HttpPost]
        public Suscripciones Actualizar(Suscripciones entidad)
        {
            return this.ISuscripcionesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Suscripciones Borrar(Suscripciones entidad)
        {
            return this.ISuscripcionesAplicacion.Borrar(entidad);
        }

    }
}
