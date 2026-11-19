using Microsoft.AspNetCore.Mvc;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Implementaciones;
using Libreria.Nucleo;

namespace Servicio_Musica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")] // Ruta base: http://localhost:5034/Album/
    public class FavoritosController : ControllerBase
    {
        // 1. Declarar las 3 interfaces de aplicación
        private IFavoritosAplicacion IFavoritosAplicacion;

        // 2. Inicializar las 3 dependencias en el constructor
        public FavoritosController(IFavoritosAplicacion IFavoritosAplicacion)
        {

            this.IFavoritosAplicacion = IFavoritosAplicacion;
            
        }

        // ==========================================
        //                Favoritos
        // ==========================================

        [HttpPost]
        public Favoritos Insertar(Favoritos entidad)
        {
            return this.IFavoritosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public List<Favoritos> Buscar(Favoritos entidad)
        {
            return this.IFavoritosAplicacion.Buscar(entidad);
        }
        
        [HttpPost]
        public IEnumerable<Favoritos> Consultar()
        {
            return this.IFavoritosAplicacion.Consultar();
        }

        [HttpPost]
        public Favoritos Actualizar(Favoritos entidad)
        {
            return this.IFavoritosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Favoritos Borrar(Favoritos entidad)
        {
            return this.IFavoritosAplicacion.Borrar(entidad);
        }

    }
}
