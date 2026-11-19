using Microsoft.AspNetCore.Mvc;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Implementaciones;
using Libreria.Nucleo;

namespace Servicio_Musica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")] // Ruta base: http://localhost:5034/Album/
    public class ReproduccionesController : ControllerBase
    {
        // 1. Declarar las 3 interfaces de aplicación
        private IReproduccionesAplicacion IReproduccionesAplicacion;

        // 2. Inicializar las 3 dependencias en el constructor
        public ReproduccionesController(IReproduccionesAplicacion IReproduccionesAplicacion)
        {

            this.IReproduccionesAplicacion = IReproduccionesAplicacion;
            
        }

        // ==========================================
        //                Reproducciones
        // ==========================================

        [HttpPost]
        public Reproducciones Insertar(Reproducciones entidad)
        {
            return this.IReproduccionesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public List<Reproducciones> Buscar(Reproducciones entidad)
        {
            return this.IReproduccionesAplicacion.Buscar(entidad);
        }
        
        [HttpPost]
        public IEnumerable<Reproducciones> Consultar()
        {
            return this.IReproduccionesAplicacion.Consultar();
        }

        [HttpPost]
        public Reproducciones Actualizar(Reproducciones entidad)
        {
            return this.IReproduccionesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Reproducciones Borrar(Reproducciones entidad)
        {
            return this.IReproduccionesAplicacion.Borrar(entidad);
        }

    }
}
