using Microsoft.AspNetCore.Mvc;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Implementaciones;
using Libreria.Nucleo;

namespace Servicio_Musica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Listas_CancionesController : ControllerBase
    {
        // 1. Declarar la interfaz de aplicación
        private IListas_CancionesAplicacion IListas_CancionesAplicacion;

        // 2. Inicializar la dependencia en el constructor
        public Listas_CancionesController(IListas_CancionesAplicacion IListas_CancionesAplicacion)
        {

            this.IListas_CancionesAplicacion = IListas_CancionesAplicacion;
            
        }

        // ==========================================
        //              Listas_Canciones
        // ==========================================

        [HttpPost]
        public Listas_Canciones Insertar(Listas_Canciones entidad)
        {
            return this.IListas_CancionesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public IEnumerable<Listas_Canciones> Consultar()
        {
            return this.IListas_CancionesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Listas_Canciones> Buscar(Listas_Canciones entidad)
        {
            return this.IListas_CancionesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Listas_Canciones Actualizar(Listas_Canciones entidad)
        {
            return this.IListas_CancionesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Listas_Canciones Borrar(Listas_Canciones entidad)
        {
            return this.IListas_CancionesAplicacion.Borrar(entidad);
        }

    }
}
