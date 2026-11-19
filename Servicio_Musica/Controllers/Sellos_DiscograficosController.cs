using Microsoft.AspNetCore.Mvc;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Implementaciones;
using Libreria.Nucleo;

namespace Servicio_Musica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Sellos_DiscograficosController : ControllerBase
    {
        // 1. Declarar las 3 interfaces de aplicación
        private ISellos_DiscograficosAplicacion ISellos_DiscograficosAplicacion;

        // 2. Inicializar las 3 dependencias en el constructor
        public Sellos_DiscograficosController(ISellos_DiscograficosAplicacion ISellos_DiscograficosAplicacion)
        {

            this.ISellos_DiscograficosAplicacion = ISellos_DiscograficosAplicacion;
            
        }

        // ==========================================
        //                Sellos_Discograficos
        // ==========================================

        [HttpPost]
        public Sellos_Discograficos Insertar(Sellos_Discograficos entidad)
        {
            return this.ISellos_DiscograficosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public List<Sellos_Discograficos> Buscar(Sellos_Discograficos entidad)
        {
            return this.ISellos_DiscograficosAplicacion.Buscar(entidad);
        }
        
        [HttpPost]
        public IEnumerable<Sellos_Discograficos> Consultar()
        {
            return this.ISellos_DiscograficosAplicacion.Consultar();
        }

        [HttpPost]
        public Sellos_Discograficos Actualizar(Sellos_Discograficos entidad)
        {
            return this.ISellos_DiscograficosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Sellos_Discograficos Borrar(Sellos_Discograficos entidad)
        {
            return this.ISellos_DiscograficosAplicacion.Borrar(entidad);
        }

    }
}
