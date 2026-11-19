using Microsoft.AspNetCore.Mvc;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Implementaciones;
using Libreria.Nucleo;

namespace Servicio_Musica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Canciones_IdiomasController : ControllerBase
    {
        // 1. Declarar la interfaz de aplicación
        private ICanciones_IdiomasAplicacion ICanciones_IdiomasAplicacion;

        // 2. Inicializar la dependencia en el constructor
        public Canciones_IdiomasController(ICanciones_IdiomasAplicacion ICanciones_IdiomasAplicacion)
        {

            this.ICanciones_IdiomasAplicacion = ICanciones_IdiomasAplicacion;
            
        }

        // ==========================================
        //              Canciones_Idiomas
        // ==========================================

        [HttpPost]
        public Canciones_Idiomas Insertar(Canciones_Idiomas entidad)
        {
            return this.ICanciones_IdiomasAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public IEnumerable<Canciones_Idiomas> Consultar()
        {
            return this.ICanciones_IdiomasAplicacion.Consultar();
        }

        [HttpPost]
        public List<Canciones_Idiomas> Buscar(Canciones_Idiomas entidad)
        {
            return this.ICanciones_IdiomasAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Canciones_Idiomas Actualizar(Canciones_Idiomas entidad)
        {
            return this.ICanciones_IdiomasAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Canciones_Idiomas Borrar(Canciones_Idiomas entidad)
        {
            return this.ICanciones_IdiomasAplicacion.Borrar(entidad);
        }

    }
}
