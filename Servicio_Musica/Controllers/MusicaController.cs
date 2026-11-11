using Microsoft.AspNetCore.Mvc;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Implementaciones;
using Libreria.Nucleo;

namespace Servicio_Musica.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class MusicaController : ControllerBase
    {
        // 1. Declarar las 3 interfaces de aplicación
        private IArtistasAplicacion IArtistasAplicacion;
        private ISellos_DiscograficosAplicacion ISellos_DiscograficosAplicacion;
        private IArtistas_SellosAplicacion IArtistas_SellosAplicacion;

        // 2. Inicializar las 3 dependencias en el constructor
        public MusicaController(IArtistasAplicacion IArtistasAplicacion,
                                ISellos_DiscograficosAplicacion ISellos_DiscograficosAplicacion,
                                IArtistas_SellosAplicacion IArtistas_SellosAplicacion)
        {

            this.IArtistas_SellosAplicacion = IArtistas_SellosAplicacion;
            this.IArtistasAplicacion = IArtistasAplicacion;
            this.ISellos_DiscograficosAplicacion = ISellos_DiscograficosAplicacion;
            
        }

        // ==========================================
        //                   Artistas
        // ==========================================
        [HttpPost("Artistas/Insertar")]
        public Artistas InsertarArtista(Artistas entidad)
        {
            return this.IArtistasAplicacion.Insertar(entidad);
        }

        [HttpGet("Artistas/Consultar")]
        public IEnumerable<Artistas> ConsultarArtistas()
        {
            return this.IArtistasAplicacion.Consultar();
        }

        [HttpPut]
        public Artistas Actualizar(Artistas entidad)
        {
            return this.IArtistasAplicacion.Actualizar(entidad);
        }

        [HttpDelete]
        public Artistas Borrar(Artistas entidad)
        {
            return this.IArtistasAplicacion.Borrar(entidad);
        }

        // ==========================================
        //            Sellos_Discograficos
        // ==========================================
        [HttpPost("Sellos_Discograficos/Insertar")]
        public Sellos_Discograficos InsertarSello(Sellos_Discograficos entidad)
        {
            return this.ISellos_DiscograficosAplicacion.Insertar(entidad);
        }

        [HttpGet("Sellos_Discograficos/Consultar")]
        public IEnumerable<Sellos_Discograficos> ConsultarSellos_Discograficos()
        {
            return this.ISellos_DiscograficosAplicacion.Consultar();
        }

        [HttpPut]
        public Sellos_Discograficos Actualizar(Sellos_Discograficos entidad)
        {
            return this.ISellos_DiscograficosAplicacion.Actualizar(entidad);
        }

        [HttpDelete]
        public Sellos_Discograficos Borrar(Sellos_Discograficos entidad)
        {
            return this.ISellos_DiscograficosAplicacion.Borrar(entidad);
        }

        // ==========================================
        //               Artistas_Sellos
        // ==========================================
        [HttpPost("Artistas_Sellos/Insertar")]
        public Artistas_Sellos InsertarArtistaSello(Artistas_Sellos entidad)
        {
            return this.IArtistas_SellosAplicacion.Insertar(entidad);
        }

        [HttpGet("Artistas_Sellos/Consultar")]
        public IEnumerable<Artistas_Sellos> ConsultarArtistas_Sellos()
        {
            return this.IArtistas_SellosAplicacion.Consultar();
        }

        [HttpPut]
        public Artistas_Sellos Actualizar(Artistas_Sellos entidad)
        {
            return this.IArtistas_SellosAplicacion.Actualizar(entidad);
        }

        [HttpDelete]
        public Artistas_Sellos Borrar(Artistas_Sellos entidad)
        {
            return this.IArtistas_SellosAplicacion.Borrar(entidad);
        }

    }
}
