using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Nucleo;
using Libreria_Front.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Front_Musica.Pages.Ventanas
{
    public class Albumes_ArtistasModel : PageModel
    {
        private IAlbumes_ArtistasPresentacion IAlbumes_ArtistasPresentacion;
        private IAlbumesPresentacion IAlbumesPresentacion;

        public Albumes_ArtistasModel(IAlbumes_ArtistasPresentacion IAlbumes_ArtistasPresentacion, 
            IAlbumesPresentacion IAlbumesPresentacion)
        {
            this.IAlbumes_ArtistasPresentacion = IAlbumes_ArtistasPresentacion;
            this.IAlbumesPresentacion = IAlbumesPresentacion;
            this.Filtro = new Albumes_Artistas();
            Filtro!._Album = new Albumes();
            Filtro!._Artista = new Artistas();
        }

        [BindProperty] public List<Albumes> Albumes { get; set; }
        [BindProperty] public List<Albumes_Artistas> Lista { get; set; }
        [BindProperty] public Albumes_Artistas? Filtro { get; set; }
        [BindProperty] public Albumes_Artistas? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;
        [BindProperty] public bool Nuevo { get; set; } = false;


        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                Filtro!._Album.Titulo = Filtro!._Album.Titulo ?? "";
                Filtro!._Artista.Nombre = Filtro!._Artista.Nombre ?? "";
                Lista = this.IAlbumes_ArtistasPresentacion.Buscar(Filtro!);
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
                this.Actual = new Albumes_Artistas();
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
                    this.Actual = this.IAlbumes_ArtistasPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IAlbumes_ArtistasPresentacion.Actualizar(this.Actual!);
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
                this.Actual = this.IAlbumes_ArtistasPresentacion.Borrar(this.Actual!);
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
