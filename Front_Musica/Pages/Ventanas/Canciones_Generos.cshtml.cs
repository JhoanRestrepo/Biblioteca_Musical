using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Nucleo;
using Libreria_Front.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Front_Musica.Pages.Ventanas
{
    public class Canciones_GenerosModel : PageModel
    {
        private ICanciones_GenerosPresentacion ICanciones_GenerosPresentacion;
        private ICancionesPresentacion ICancionesPresentacion;
        private IGenerosPresentacion IGenerosPresentacion;

        public Canciones_GenerosModel(ICanciones_GenerosPresentacion ICanciones_GenerosPresentacion,
            ICancionesPresentacion ICancionesPresentacion,
            IGenerosPresentacion IGenerosPresentacion)
        {
            this.ICanciones_GenerosPresentacion = ICanciones_GenerosPresentacion;
            this.ICancionesPresentacion = ICancionesPresentacion;
            this.IGenerosPresentacion = IGenerosPresentacion;
            this.Filtro = new Canciones_Generos();
            this.Filtro._Cancion = new Canciones();
            this.Filtro._Genero = new Generos();
        }

        [BindProperty] public List<Canciones_Generos> Lista { get; set; }
        [BindProperty] public List<Canciones>? Canciones { get; set; }
        [BindProperty] public List<Generos>? Generos { get; set; }
        [BindProperty] public Canciones_Generos? Filtro { get; set; }
        [BindProperty] public Canciones_Generos? Actual { get; set; }
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
                Filtro!._Genero!.Nombre = Filtro!._Genero!.Nombre ?? "";
                Lista = this.ICanciones_GenerosPresentacion.Buscar(Filtro!);
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
                this.Actual = new Canciones_Generos();
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
                    this.Actual = this.ICanciones_GenerosPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.ICanciones_GenerosPresentacion.Actualizar(this.Actual!);
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
                this.Actual = this.ICanciones_GenerosPresentacion.Borrar(this.Actual!);
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
