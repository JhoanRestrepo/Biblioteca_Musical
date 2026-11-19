using Microsoft.AspNetCore.Mvc;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Implementaciones;
using Libreria.Nucleo;

namespace Servicio_Musica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LR_CancionesController : ControllerBase
    {
        // 1. Declarar la interfaz de aplicación
        private ILR_CancionesAplicacion ILR_CancionesAplicacion;

        // 2. Inicializar la dependencia en el constructor
        public LR_CancionesController(ILR_CancionesAplicacion ILR_CancionesAplicacion)
        {

            this.ILR_CancionesAplicacion = ILR_CancionesAplicacion;
            
        }

        // ==========================================
        //              LR_Canciones
        // ==========================================

        [HttpPost]
        public LR_Canciones Insertar(LR_Canciones entidad)
        {
            return this.ILR_CancionesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public IEnumerable<LR_Canciones> Consultar()
        {
            return this.ILR_CancionesAplicacion.Consultar();
        }

        [HttpPost]
        public List<LR_Canciones> Buscar(LR_Canciones entidad)
        {
            return this.ILR_CancionesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public LR_Canciones Actualizar(LR_Canciones entidad)
        {
            return this.ILR_CancionesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public LR_Canciones Borrar(LR_Canciones entidad)
        {
            return this.ILR_CancionesAplicacion.Borrar(entidad);
        }

    }
}
