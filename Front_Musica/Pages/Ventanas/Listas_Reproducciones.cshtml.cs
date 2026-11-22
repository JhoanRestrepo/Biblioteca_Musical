using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Nucleo;
using Libreria_Front.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Front_Musica.Pages.Ventanas
{
    public class Listas_ReproduccionesModel : PageModel
    {
        private IListas_ReproduccionesPresentacion IListas_ReproduccionesPresentacion;

        public Listas_ReproduccionesModel(IListas_ReproduccionesPresentacion IListas_ReproduccionesPresentacion)
        {
            this.IListas_ReproduccionesPresentacion = IListas_ReproduccionesPresentacion;
            this.Filtro = new Listas_Reproducciones();
        }

        public IFormFile? FormFile { get; set; }
        [BindProperty] public List<Listas_Reproducciones> Lista { get; set; }
        [BindProperty] public Listas_Reproducciones? Filtro { get; set; }
        [BindProperty] public Listas_Reproducciones? Actual { get; set; }
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
                Filtro!.Nombre = Filtro!.Nombre ?? "";
                Lista = this.IListas_ReproduccionesPresentacion.Buscar(Filtro!);
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
                this.Actual = new Listas_Reproducciones();
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
                    this.Actual = this.IListas_ReproduccionesPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IListas_ReproduccionesPresentacion.Actualizar(this.Actual!);
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
                this.Actual = this.IListas_ReproduccionesPresentacion.Borrar(this.Actual!);
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
