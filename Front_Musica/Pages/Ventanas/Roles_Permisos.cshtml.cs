using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Nucleo;
using Libreria_Front.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Front_Musica.Pages.Ventanas
{
    public class Roles_PermisosModel : PageModel
    {
        private IRoles_PermisosPresentacion IRoles_PermisosPresentacion;
        private IRolesPresentacion IRolesPresentacion;
        private IPermisosPresentacion IPermisosPresentacion;


        public Roles_PermisosModel(IRoles_PermisosPresentacion IRoles_PermisosPresentacion,
                                    IRolesPresentacion IRolesPresentacion,
                                    IPermisosPresentacion IPermisosPresentacion)
        {
            this.IRoles_PermisosPresentacion = IRoles_PermisosPresentacion;
            this.IRolesPresentacion = IRolesPresentacion;
            this.IPermisosPresentacion = IPermisosPresentacion;

            this.Filtro = new Roles_Permisos();
            Filtro!._Rol = new Roles();
            Filtro!._Permiso = new Permisos();
        }

        [BindProperty] public List<Roles> Roles { get; set; }
        [BindProperty] public List<Permisos> Permisos { get; set; }
        [BindProperty] public List<Roles_Permisos> Lista { get; set; }
        [BindProperty] public Roles_Permisos? Filtro { get; set; }
        [BindProperty] public Roles_Permisos? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;
        [BindProperty] public bool Nuevo { get; set; } = false;

        public void OnGet() { 
            
            CargarListas();
            OnPostBtConsultar();
        }

        private void CargarListas()
        {
            Roles = IRolesPresentacion.Consultar();
            Permisos = IPermisosPresentacion.Consultar();
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
                Filtro!._Rol.Nombre = Filtro!._Rol.Nombre ?? "";
                Filtro!._Permiso.Nombre = Filtro!._Permiso.Nombre ?? "";
                Lista = this.IRoles_PermisosPresentacion.Buscar(Filtro!);
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
                this.Actual = new Roles_Permisos();
                Filtro!._Rol.Nombre = Filtro!._Rol.Nombre;
                Filtro!._Permiso.Nombre = Filtro!._Permiso.Nombre;
                Lista = this.IRoles_PermisosPresentacion.Buscar(Filtro);
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
                    this.Actual = this.IRoles_PermisosPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IRoles_PermisosPresentacion.Actualizar(this.Actual!);
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
                this.Actual = this.IRoles_PermisosPresentacion.Borrar(this.Actual!);
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
