using Microsoft.AspNetCore.Mvc;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Implementaciones;
using Libreria.Nucleo;

namespace Servicio_Musica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GenerosController : ControllerBase
    {
        // 1. Declarar las 3 interfaces de aplicación
        private IGenerosAplicacion IGenerosAplicacion;

        // 2. Inicializar las 3 dependencias en el constructor
        public GenerosController(IGenerosAplicacion IGenerosAplicacion)
        {

            this.IGenerosAplicacion = IGenerosAplicacion;
            
        }

        // ==========================================
        //                Generos
        // ==========================================

        [HttpPost]
        public Generos Insertar(Generos entidad)
        {
            return this.IGenerosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public List<Generos> Buscar(Generos entidad)
        {
            return this.IGenerosAplicacion.Buscar(entidad);
        }
        
        [HttpPost]
        public IEnumerable<Generos> Consultar()
        {
            return this.IGenerosAplicacion.Consultar();
        }

        [HttpPost]
        public Generos Actualizar(Generos entidad)
        {
            return this.IGenerosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Generos Borrar(Generos entidad)
        {
            return this.IGenerosAplicacion.Borrar(entidad);
        }

    }
}
