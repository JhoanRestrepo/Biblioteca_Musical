using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Nucleo;
using Libreria_Front.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Front_Musica.Pages.Ventanas
{
    public class Usuarios_RolesModel : PageModel
    {
        private IUsuarios_RolesPresentacion IUsuarios_RolesPresentacion;
        private IUsuariosPresentacion IUsuariosPresentacion;
        private IRolesPresentacion IRolesPresentacion;


        public Usuarios_RolesModel(IUsuarios_RolesPresentacion IUsuarios_RolesPresentacion, 
                                    IUsuariosPresentacion IUsuariosPresentacion,
                                    IRolesPresentacion IRolesPresentacion)
        {
            this.IUsuarios_RolesPresentacion = IUsuarios_RolesPresentacion;
            this.IUsuariosPresentacion = IUsuariosPresentacion;
            this.IRolesPresentacion = IRolesPresentacion;

            this.Filtro = new Usuarios_Roles();
            Filtro!._Usuario = new Usuarios();
            Filtro!._Rol = new Roles();
        }

        [BindProperty] public List<Usuarios> Usuarios { get; set; }
        [BindProperty] public List<Roles> Roles { get; set; }
        [BindProperty] public List<Usuarios_Roles> Lista { get; set; }
        [BindProperty] public Usuarios_Roles? Filtro { get; set; }
        [BindProperty] public Usuarios_Roles? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;
        [BindProperty] public bool Nuevo { get; set; } = false;

        public void OnGet() { 
            
            CargarListas();
            OnPostBtConsultar();
        }

        private void CargarListas()
        {
            Usuarios = IUsuariosPresentacion.Consultar();
            Roles = IRolesPresentacion.Consultar();
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
                Filtro!._Rol.Nombre = Filtro!._Rol.Nombre ?? "";
                Lista = this.IUsuarios_RolesPresentacion.Buscar(Filtro!);
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
                this.Actual = new Usuarios_Roles();
                Filtro!._Usuario.Nombre = Filtro!._Usuario.Nombre;
                Filtro!._Rol.Nombre = Filtro!._Rol.Nombre;
                Lista = this.IUsuarios_RolesPresentacion.Buscar(Filtro);
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
                    this.Actual = this.IUsuarios_RolesPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IUsuarios_RolesPresentacion.Actualizar(this.Actual!);
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
                this.Actual = this.IUsuarios_RolesPresentacion.Borrar(this.Actual!);
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
