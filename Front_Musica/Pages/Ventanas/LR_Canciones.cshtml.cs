using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Nucleo;
using Libreria_Front.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Front_Musica.Pages.Ventanas
{
    public class LR_CancionesModel : PageModel
    {
        private ILR_CancionesPresentacion ILR_CancionesPresentacion;
        private ICancionesPresentacion ICancionesPresentacion;
        private IGenerosPresentacion IGenerosPresentacion;

        public LR_CancionesModel(ILR_CancionesPresentacion ILR_CancionesPresentacion,
            ICancionesPresentacion ICancionesPresentacion,
            IGenerosPresentacion IGenerosPresentacion)
        {
            this.ILR_CancionesPresentacion = ILR_CancionesPresentacion;
            this.ICancionesPresentacion = ICancionesPresentacion;
            this.IGenerosPresentacion = IGenerosPresentacion;
            this.Filtro = new LR_Canciones();
            this.Filtro._Cancion = new Canciones();
            this.Filtro._Lista_Reproduccion = new Listas_Reproducciones();
        }

        [BindProperty] public List<LR_Canciones> Lista { get; set; }
        [BindProperty] public List<Canciones>? Canciones { get; set; }
        [BindProperty] public List<Generos>? Generos { get; set; }
        [BindProperty] public LR_Canciones? Filtro { get; set; }
        [BindProperty] public LR_Canciones? Actual { get; set; }
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
                Filtro!._Lista_Reproduccion!.Nombre = Filtro!._Lista_Reproduccion!.Nombre ?? "";
                Lista = this.ILR_CancionesPresentacion.Buscar(Filtro!);
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
                this.Actual = new LR_Canciones();
                this.Canciones = this.ICancionesPresentacion.Buscar(new Canciones() { Titulo = "" });
                this.Generos = this.IGenerosPresentacion.Buscar(new Generos() { Nombre = "" });
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
                    this.Actual = this.ILR_CancionesPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.ILR_CancionesPresentacion.Actualizar(this.Actual!);
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
                this.Generos = this.IGenerosPresentacion.Buscar(new Generos() { Nombre = "" });
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
                this.Actual = this.ILR_CancionesPresentacion.Borrar(this.Actual!);
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
