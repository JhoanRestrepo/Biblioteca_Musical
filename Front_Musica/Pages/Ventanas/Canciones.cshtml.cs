using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Nucleo;
using Libreria_Front.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Front_Musica.Pages.Ventanas
{
    public class CancionesModel : PageModel
    {
        private ICancionesPresentacion ICancionesPresentacion;
        private IAlbumesPresentacion IAlbumesPresentacion;

        public CancionesModel(ICancionesPresentacion ICancionesPresentacion,
                                IAlbumesPresentacion IAlbumesPresentacion)
        {
            this.ICancionesPresentacion = ICancionesPresentacion;
            this.IAlbumesPresentacion = IAlbumesPresentacion;
            
            this.Filtro = new Canciones();
            Filtro!._Album = new Albumes();
        }

        public IFormFile? FormFile { get; set; }
        [BindProperty] public List<Canciones> Lista { get; set; }
        [BindProperty] public List<Albumes> Albumes { get; set; }
        [BindProperty] public Canciones? Filtro { get; set; }
        [BindProperty] public Canciones? Actual { get; set; }
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
            Albumes = IAlbumesPresentacion.Consultar();
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
                Filtro!.Titulo = Filtro!.Titulo ?? "";
                Lista = this.ICancionesPresentacion.Buscar(Filtro!);
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
                this.Actual = new Canciones();
                this.Albumes = this.IAlbumesPresentacion.Consultar();
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
                    this.Actual = this.ICancionesPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.ICancionesPresentacion.Actualizar(this.Actual!);
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
                this.Albumes = this.IAlbumesPresentacion.Consultar();
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
                this.Actual = this.ICancionesPresentacion.Borrar(this.Actual!);
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
