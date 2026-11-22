using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Nucleo;
using Libreria_Front.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Front_Musica.Pages.Ventanas
{
    public class Canciones_CompositoresModel : PageModel
    {
        private ICanciones_CompositoresPresentacion ICanciones_CompositoresPresentacion;
        private ICancionesPresentacion ICancionesPresentacion;
        private ICompositoresPresentacion ICompositoresPresentacion;

        public Canciones_CompositoresModel(ICanciones_CompositoresPresentacion ICanciones_CompositoresPresentacion,
            ICancionesPresentacion ICancionesPresentacion,
            ICompositoresPresentacion ICompositoresPresentacion)
        {
            this.ICanciones_CompositoresPresentacion = ICanciones_CompositoresPresentacion;
            this.ICancionesPresentacion = ICancionesPresentacion;
            this.ICompositoresPresentacion = ICompositoresPresentacion;
            this.Filtro = new Canciones_Compositores();
            this.Filtro._Cancion = new Canciones();
            this.Filtro._Compositor = new Compositores();
        }

        [BindProperty] public List<Canciones_Compositores> Lista { get; set; }
        [BindProperty] public List<Canciones>? Canciones { get; set; }
        [BindProperty] public List<Compositores>? Compositores { get; set; }
        [BindProperty] public Canciones_Compositores? Filtro { get; set; }
        [BindProperty] public Canciones_Compositores? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;
        [BindProperty] public bool Nuevo { get; set; } = false;


        public void OnGet() { OnPostBtConsultar(); }

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
                Filtro!._Cancion!.Titulo = Filtro!._Cancion!.Titulo ?? "";
                Filtro!._Compositor!.Nombre = Filtro!._Compositor!.Nombre ?? "";
                Lista = this.ICanciones_CompositoresPresentacion.Buscar(Filtro!);
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
                Formulario = true;
                this.Actual = new Canciones_Compositores();
                this.Canciones = this.ICancionesPresentacion.Buscar(new Canciones() { Titulo = "" });
                this.Compositores = this.ICompositoresPresentacion.Buscar(new Compositores() { Nombre = "" });
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
                    this.Actual = this.ICanciones_CompositoresPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.ICanciones_CompositoresPresentacion.Actualizar(this.Actual!);
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

        public void OnPostBtEditar(string data)
        {
            try
            {
                Formulario = true;
                OnPostBtConsultar();
                this.Actual = this.Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
                this.Canciones = this.ICancionesPresentacion.Buscar(new Canciones() { Titulo = "" });
                this.Compositores = this.ICompositoresPresentacion.Buscar(new Compositores() { Nombre = "" });
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
                this.Actual = this.ICanciones_CompositoresPresentacion.Borrar(this.Actual!);
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
