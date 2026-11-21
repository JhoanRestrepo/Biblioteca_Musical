using Microsoft.AspNetCore.Mvc;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Implementaciones;
using Libreria.Nucleo;

namespace Servicio_Musica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")] // Ruta base: http://localhost:5034/Album/
    public class IdiomasController : ControllerBase
    {
        // 1. Declarar las 3 interfaces de aplicación
        private I_IdiomasAplicacion I_IdiomasAplicacion;

        // 2. Inicializar las 3 dependencias en el constructor
        public IdiomasController(I_IdiomasAplicacion I_IdiomasAplicacion)
        {

            this.I_IdiomasAplicacion = I_IdiomasAplicacion;
            
        }

        // ==========================================
        //                Idiomas
        // ==========================================

        [HttpPost]
        public Idiomas Insertar(Idiomas entidad)
        {
            return this.I_IdiomasAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public List<Idiomas> Buscar(Idiomas entidad)
        {
            return this.I_IdiomasAplicacion.Buscar(entidad);
        }
        
        [HttpPost]
        public IEnumerable<Idiomas> Consultar()
        {
            return this.I_IdiomasAplicacion.Consultar();
        }

        [HttpPost]
        public Idiomas Actualizar(Idiomas entidad)
        {
            return this.I_IdiomasAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Idiomas Borrar(Idiomas entidad)
        {
            return this.I_IdiomasAplicacion.Borrar(entidad);
        }

    }
}
