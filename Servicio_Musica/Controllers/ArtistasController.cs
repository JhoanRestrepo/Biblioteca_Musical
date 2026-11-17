using Microsoft.AspNetCore.Mvc;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Implementaciones;
using Libreria.Nucleo;

namespace Servicio_Musica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ArtistasController : ControllerBase
    {
        // 1. Declarar las 3 interfaces de aplicación
        private IArtistasAplicacion IArtistasAplicacion;

        // 2. Inicializar las 3 dependencias en el constructor
        public ArtistasController(IArtistasAplicacion IArtistasAplicacion)
        {

            this.IArtistasAplicacion = IArtistasAplicacion;
            
        }

        // ==========================================
        //                Artistas
        // ==========================================

        [HttpPost]
        public Artistas Insertar(Artistas entidad)
        {
            return this.IArtistasAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public List<Artistas> Buscar(Artistas entidad)
        {
            return this.IArtistasAplicacion.Buscar(entidad);
        }
        
        [HttpPost]
        public IEnumerable<Artistas> Consultar()
        {
            return this.IArtistasAplicacion.Consultar();
        }

        [HttpPost]
        public Artistas Actualizar(Artistas entidad)
        {
            return this.IArtistasAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Artistas Borrar(Artistas entidad)
        {
            return this.IArtistasAplicacion.Borrar(entidad);
        }

    }
}
