using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Nucleo;
using Libreria_Front.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Front_Musica.Pages.Ventanas
{
    public class ArtistasModel : PageModel
    {
        private IArtistasPresentacion IArtistasPresentacion;

        public ArtistasModel(IArtistasPresentacion IArtistasPresentacion)
        {
            this.IArtistasPresentacion = IArtistasPresentacion;
            this.Filtro = new Artistas();
        }

        public IFormFile? FormFile { get; set; }
        [BindProperty] public List<Artistas> Lista { get; set; }
        [BindProperty] public Artistas? Filtro { get; set; }
        [BindProperty] public Artistas? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;
        [BindProperty] public bool Nuevo { get; set; } = false;


        public void OnGet() 
        { 
            OnPostBtConsultar();
        }

        private bool TienePermiso(string codigo)
        {
            var permisos = HttpContext.Session.GetString("Permisos") ?? "";
            return permisos.Split(',', StringSplitOptions.RemoveEmptyEntries)
                           .Contains(codigo, StringComparer.OrdinalIgnoreCase);
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
                Filtro!.Nombre = Filtro!.Nombre ?? "";
                Lista = this.IArtistasPresentacion.Buscar(Filtro!);
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
                if (!TienePermiso("020"))
                {
                    ViewData["Mensaje"] = "No tienes permiso para crear registros.";
                    return;
                }

                Formulario = true;
                this.Actual = new Artistas();
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
                    this.Actual = this.IArtistasPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IArtistasPresentacion.Actualizar(this.Actual!);
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
                if (!TienePermiso("020"))
                {
                    ViewData["Mensaje"] = "No tienes permiso para editar registros.";
                    return;
                }

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
                var variable_session = HttpContext.Session.GetString("Usuario");
                if (string.IsNullOrEmpty(variable_session))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }

                var permisos = HttpContext.Session.GetString("Permisos") ?? "";
                var listaPermisos = permisos.Split(',', StringSplitOptions.RemoveEmptyEntries);

                // "030" = Eliminar
                if (!listaPermisos.Contains("030"))
                {
                    ViewData["Mensaje"] = "No tienes permiso para eliminar registros.";
                    return;
                }

                if (this.Actual!.Id == 0)
                    return;

                this.Actual = this.IArtistasPresentacion.Borrar(this.Actual!);
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
