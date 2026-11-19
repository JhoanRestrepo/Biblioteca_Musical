using Microsoft.AspNetCore.Mvc;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Implementaciones;
using Libreria.Nucleo;

namespace Servicio_Musica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Canciones_CompositoresController : ControllerBase
    {
        // 1. Declarar la interfaz de aplicación
        private ICanciones_CompositoresAplicacion ICanciones_CompositoresAplicacion;

        // 2. Inicializar la dependencia en el constructor
        public Canciones_CompositoresController(ICanciones_CompositoresAplicacion ICanciones_CompositoresAplicacion)
        {

            this.ICanciones_CompositoresAplicacion = ICanciones_CompositoresAplicacion;
            
        }

        // ==========================================
        //              Canciones_Compositores
        // ==========================================

        [HttpPost]
        public Canciones_Compositores Insertar(Canciones_Compositores entidad)
        {
            return this.ICanciones_CompositoresAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public IEnumerable<Canciones_Compositores> Consultar()
        {
            return this.ICanciones_CompositoresAplicacion.Consultar();
        }

        [HttpPost]
        public List<Canciones_Compositores> Buscar(Canciones_Compositores entidad)
        {
            return this.ICanciones_CompositoresAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Canciones_Compositores Actualizar(Canciones_Compositores entidad)
        {
            return this.ICanciones_CompositoresAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Canciones_Compositores Borrar(Canciones_Compositores entidad)
        {
            return this.ICanciones_CompositoresAplicacion.Borrar(entidad);
        }

    }
}
