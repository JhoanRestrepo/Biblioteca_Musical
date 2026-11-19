using Microsoft.AspNetCore.Mvc;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Implementaciones;
using Libreria.Nucleo;

namespace Servicio_Musica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Canciones_GenerosController : ControllerBase
    {
        // 1. Declarar la interfaz de aplicación
        private ICanciones_GenerosAplicacion ICanciones_GenerosAplicacion;

        // 2. Inicializar la dependencia en el constructor
        public Canciones_GenerosController(ICanciones_GenerosAplicacion ICanciones_GenerosAplicacion)
        {

            this.ICanciones_GenerosAplicacion = ICanciones_GenerosAplicacion;
            
        }

        // ==========================================
        //              Canciones_Generos
        // ==========================================

        [HttpPost]
        public Canciones_Generos Insertar(Canciones_Generos entidad)
        {
            return this.ICanciones_GenerosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public IEnumerable<Canciones_Generos> Consultar()
        {
            return this.ICanciones_GenerosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Canciones_Generos> Buscar(Canciones_Generos entidad)
        {
            return this.ICanciones_GenerosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Canciones_Generos Actualizar(Canciones_Generos entidad)
        {
            return this.ICanciones_GenerosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Canciones_Generos Borrar(Canciones_Generos entidad)
        {
            return this.ICanciones_GenerosAplicacion.Borrar(entidad);
        }

    }
}
