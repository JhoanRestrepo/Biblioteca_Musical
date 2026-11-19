using Microsoft.AspNetCore.Mvc;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Implementaciones;
using Libreria.Nucleo;

namespace Servicio_Musica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CompositoresController : ControllerBase
    {
        // 1. Declarar las 3 interfaces de aplicación
        private ICompositoresAplicacion ICompositoresAplicacion;

        // 2. Inicializar las 3 dependencias en el constructor
        public CompositoresController(ICompositoresAplicacion ICompositoresAplicacion)
        {

            this.ICompositoresAplicacion = ICompositoresAplicacion;
            
        }

        // ==========================================
        //                Compositores
        // ==========================================

        [HttpPost]
        public Compositores Insertar(Compositores entidad)
        {
            return this.ICompositoresAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public List<Compositores> Buscar(Compositores entidad)
        {
            return this.ICompositoresAplicacion.Buscar(entidad);
        }
        
        [HttpPost]
        public IEnumerable<Compositores> Consultar()
        {
            return this.ICompositoresAplicacion.Consultar();
        }

        [HttpPost]
        public Compositores Actualizar(Compositores entidad)
        {
            return this.ICompositoresAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Compositores Borrar(Compositores entidad)
        {
            return this.ICompositoresAplicacion.Borrar(entidad);
        }

    }
}
