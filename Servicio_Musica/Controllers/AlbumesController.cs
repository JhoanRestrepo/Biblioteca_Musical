using Microsoft.AspNetCore.Mvc;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Implementaciones;
using Libreria.Nucleo;

namespace Servicio_Musica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")] // Ruta base: http://localhost:5034/Album/
    public class AlbumesController : ControllerBase
    {
        // 1. Declarar las 3 interfaces de aplicación
        private IAlbumesAplicacion IAlbumesAplicacion;

        // 2. Inicializar las 3 dependencias en el constructor
        public AlbumesController(IAlbumesAplicacion IAlbumesAplicacion)
        {

            this.IAlbumesAplicacion = IAlbumesAplicacion;
            
        }

        // ==========================================
        //                Albumes
        // ==========================================

        [HttpPost]
        public Albumes Insertar(Albumes entidad)
        {
            return this.IAlbumesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public List<Albumes> Buscar(Albumes entidad)
        {
            return this.IAlbumesAplicacion.Buscar(entidad);
        }
        
        [HttpGet]
        public IEnumerable<Albumes> Consultar()
        {
            return this.IAlbumesAplicacion.Consultar();
        }

        [HttpPost]
        public Albumes Actualizar(Albumes entidad)
        {
            return this.IAlbumesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Albumes Borrar(Albumes entidad)
        {
            return this.IAlbumesAplicacion.Borrar(entidad);
        }

    }
}
