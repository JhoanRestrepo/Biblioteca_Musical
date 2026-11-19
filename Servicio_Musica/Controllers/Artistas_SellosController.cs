using Microsoft.AspNetCore.Mvc;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Implementaciones;
using Libreria.Nucleo;

namespace Servicio_Musica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Artistas_SellosController : ControllerBase
    {
        // 1. Declarar la interfaz de aplicación
        private IArtistas_SellosAplicacion IArtistas_SellosAplicacion;

        // 2. Inicializar la dependencia en el constructor
        public Artistas_SellosController(IArtistas_SellosAplicacion IArtistas_SellosAplicacion)
        {

            this.IArtistas_SellosAplicacion = IArtistas_SellosAplicacion;
            
        }

        // ==========================================
        //              Artistas_Sellos
        // ==========================================

        [HttpPost]
        public Artistas_Sellos Insertar(Artistas_Sellos entidad)
        {
            return this.IArtistas_SellosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public IEnumerable<Artistas_Sellos> Consultar()
        {
            return this.IArtistas_SellosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Artistas_Sellos> Buscar(Artistas_Sellos entidad)
        {
            return this.IArtistas_SellosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Artistas_Sellos Actualizar(Artistas_Sellos entidad)
        {
            return this.IArtistas_SellosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Artistas_Sellos Borrar(Artistas_Sellos entidad)
        {
            return this.IArtistas_SellosAplicacion.Borrar(entidad);
        }

    }
}
