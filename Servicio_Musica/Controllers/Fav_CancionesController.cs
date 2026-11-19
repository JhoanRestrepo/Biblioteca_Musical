using Microsoft.AspNetCore.Mvc;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Implementaciones;
using Libreria.Nucleo;

namespace Servicio_Musica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Fav_CancionesController : ControllerBase
    {
        // 1. Declarar la interfaz de aplicación
        private IFav_CancionesAplicacion IFav_CancionesAplicacion;

        // 2. Inicializar la dependencia en el constructor
        public Fav_CancionesController(IFav_CancionesAplicacion IFav_CancionesAplicacion)
        {

            this.IFav_CancionesAplicacion = IFav_CancionesAplicacion;
            
        }

        // ==========================================
        //              Fav_Canciones
        // ==========================================

        [HttpPost]
        public Fav_Canciones Insertar(Fav_Canciones entidad)
        {
            return this.IFav_CancionesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public IEnumerable<Fav_Canciones> Consultar()
        {
            return this.IFav_CancionesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Fav_Canciones> Buscar(Fav_Canciones entidad)
        {
            return this.IFav_CancionesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Fav_Canciones Actualizar(Fav_Canciones entidad)
        {
            return this.IFav_CancionesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Fav_Canciones Borrar(Fav_Canciones entidad)
        {
            return this.IFav_CancionesAplicacion.Borrar(entidad);
        }

    }
}
