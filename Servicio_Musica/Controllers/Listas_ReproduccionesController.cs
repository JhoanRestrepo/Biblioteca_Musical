using Microsoft.AspNetCore.Mvc;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Implementaciones;
using Libreria.Nucleo;

namespace Servicio_Musica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Listas_ReproduccionesController : ControllerBase
    {
        // 1. Declarar la interfaz de aplicación
        private IListas_ReproduccionesAplicacion IListas_ReproduccionesAplicacion;

        // 2. Inicializar la dependencia en el constructor
        public Listas_ReproduccionesController(IListas_ReproduccionesAplicacion IListas_ReproduccionesAplicacion)
        {

            this.IListas_ReproduccionesAplicacion = IListas_ReproduccionesAplicacion;
            
        }

        // ==========================================
        //              Listas_Reproducciones
        // ==========================================

        [HttpPost]
        public Listas_Reproducciones Insertar(Listas_Reproducciones entidad)
        {
            return this.IListas_ReproduccionesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public IEnumerable<Listas_Reproducciones> Consultar()
        {
            return this.IListas_ReproduccionesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Listas_Reproducciones> Buscar(Listas_Reproducciones entidad)
        {
            return this.IListas_ReproduccionesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Listas_Reproducciones Actualizar(Listas_Reproducciones entidad)
        {
            return this.IListas_ReproduccionesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Listas_Reproducciones Borrar(Listas_Reproducciones entidad)
        {
            return this.IListas_ReproduccionesAplicacion.Borrar(entidad);
        }

    }
}
