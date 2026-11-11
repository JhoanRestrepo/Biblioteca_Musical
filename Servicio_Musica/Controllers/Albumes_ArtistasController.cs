using Microsoft.AspNetCore.Mvc;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Implementaciones;
using Libreria.Nucleo;

namespace Servicio_Musica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Albumes_ArtistasController : ControllerBase
    {
        // 1. Declarar la interfaz de aplicación
        private IAlbumes_ArtistasAplicacion IAlbumes_ArtistasAplicacion;

        // 2. Inicializar la dependencia en el constructor
        public Albumes_ArtistasController(IAlbumes_ArtistasAplicacion IAlbumes_ArtistasAplicacion)
        {

            this.IAlbumes_ArtistasAplicacion = IAlbumes_ArtistasAplicacion;
            
        }

        // ==========================================
        //              Albumes_Artistas
        // ==========================================

        [HttpPost]
        public Albumes_Artistas Insertar(Albumes_Artistas entidad)
        {
            return this.IAlbumes_ArtistasAplicacion.Insertar(entidad);
        }

        [HttpGet]
        public IEnumerable<Albumes_Artistas> Consultar()
        {
            return this.IAlbumes_ArtistasAplicacion.Consultar();
        }

        [HttpPut]
        public Albumes_Artistas Actualizar(Albumes_Artistas entidad)
        {
            return this.IAlbumes_ArtistasAplicacion.Actualizar(entidad);
        }

        [HttpDelete]
        public Albumes_Artistas Borrar(Albumes_Artistas entidad)
        {
            return this.IAlbumes_ArtistasAplicacion.Borrar(entidad);
        }

    }
}
