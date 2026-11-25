using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Nucleo;
using Libreria_Front.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Front_Musica.Pages.Ventanas
{
    public class Listas_CancionesModel : PageModel
    {
        private IListas_CancionesPresentacion IListas_CancionesPresentacion;
        private ICancionesPresentacion ICancionesPresentacion;
        private IFavoritosPresentacion IFavoritosPresentacion;

        public Listas_CancionesModel(IListas_CancionesPresentacion IListas_CancionesPresentacion,
                                        ICancionesPresentacion ICancionesPresentacion,
                                        IFavoritosPresentacion IFavoritosPresentacion)
        {
            this.IListas_CancionesPresentacion = IListas_CancionesPresentacion;
            this.ICancionesPresentacion = ICancionesPresentacion;
            this.IFavoritosPresentacion = IFavoritosPresentacion;

            this.Filtro = new Listas_Canciones();
            Filtro!._Cancion = new Canciones();
            Filtro!._Favorita = new Favoritos();
        }

        public IFormFile? FormFile { get; set; }
        [BindProperty] public List<Listas_Canciones> Lista { get; set; }
        [BindProperty] public List<Canciones> Canciones { get; set; }
        [BindProperty] public List<Favoritos> Favoritos { get; set; }
        [BindProperty] public Listas_Canciones? Filtro { get; set; }
        [BindProperty] public Listas_Canciones? Actual { get; set; }
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
            Canciones = ICancionesPresentacion.Consultar();
            Favoritos = IFavoritosPresentacion.Consultar();
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
                Filtro!._Cancion.Titulo = Filtro!._Cancion.Titulo ?? "";
                Filtro!._Favorita.Activo = Filtro!._Favorita.Activo;
                Lista = this.IListas_CancionesPresentacion.Buscar(Filtro!);
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
                this.Actual = new Listas_Canciones();
                Filtro!._Cancion.Titulo = Filtro!._Cancion.Titulo;
                Filtro!._Favorita.Activo = Filtro!._Favorita.Activo;
                Lista = this.IListas_CancionesPresentacion.Consultar();
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
                    this.Actual = this.IListas_CancionesPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IListas_CancionesPresentacion.Actualizar(this.Actual!);
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
                this.Actual = this.IListas_CancionesPresentacion.Borrar(this.Actual!);
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
