using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Nucleo;
using Libreria_Front.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Front_Musica.Pages.Ventanas
{
    public class ReproduccionesModel : PageModel
    {
        private IReproduccionesPresentacion IReproduccionesPresentacion;
        private IUsuariosPresentacion IUsuariosPresentacion;
        private ICancionesPresentacion ICancionesPresentacion;

        public ReproduccionesModel(IReproduccionesPresentacion IReproduccionesPresentacion,
                                    IUsuariosPresentacion IUsuariosPresentacion,
                                    ICancionesPresentacion ICancionesPresentacion)
        {
            this.IReproduccionesPresentacion = IReproduccionesPresentacion;
            this.IUsuariosPresentacion = IUsuariosPresentacion;
            this.ICancionesPresentacion = ICancionesPresentacion;

            this.Filtro = new Reproducciones();
            Filtro!._Usuario = new Usuarios();
            Filtro!._Cancion = new Canciones();
        }

        public IFormFile? FormFile { get; set; }
        [BindProperty] public List<Reproducciones> Lista { get; set; }
        [BindProperty] public List<Usuarios> Usuarios { get; set; }
        [BindProperty] public List<Canciones> Canciones { get; set; }
        [BindProperty] public Reproducciones? Filtro { get; set; }
        [BindProperty] public Reproducciones? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;
        [BindProperty] public bool Nuevo { get; set; } = false;


        public void OnGet()
        {

            CargarListas();
            OnPostBtConsultar();
        }

        private void CargarListas()
        {
            Usuarios = IUsuariosPresentacion.Consultar();
            Canciones = ICancionesPresentacion.Consultar();
        }
        public void OnPostBtConsultar()
        {
            try
            {
                var variable_session = HttpContext.Session.GetString("Usuario");
                if (String.IsNullOrEmpty(variable_session))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }
                CargarListas();
                Filtro!._Usuario.Nombre = Filtro!._Usuario.Nombre ?? "";
                Filtro!._Cancion.Titulo = Filtro!._Cancion.Titulo ?? "";
                Lista = this.IReproduccionesPresentacion.Buscar(Filtro!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtNuevo()
        {
            try
            {
                CargarListas();
                Formulario = true;
                this.Actual = new Reproducciones();
                Filtro!._Usuario.Nombre = Filtro!._Usuario.Nombre ?? "";
                Filtro!._Cancion.Titulo = Filtro!._Cancion.Titulo ?? "";
                Lista = this.IReproduccionesPresentacion.Consultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (this.Actual!.Id == 0)
                    this.Actual = this.IReproduccionesPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IReproduccionesPresentacion.Actualizar(this.Actual!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            finally
            {
                CargarListas();
                OnPostBtConsultar();
            }
        }

        public void OnPostBtEditar(string data)
        {
            try
            {
                Formulario = true;
                OnPostBtConsultar();
                this.Actual = this.Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtPregBorrar(string data)
        {
            try
            {
                Borrar = true;
                OnPostBtConsultar();
                this.Actual = this.Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (this.Actual!.Id == 0)
                    return;
                this.Actual = this.IReproduccionesPresentacion.Borrar(this.Actual!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            finally
            {
                OnPostBtConsultar();
            }
        }
    }
}
