using Front_Musica.Utilidades;
using Libreria.Entidades;
using Libreria.Nucleo;
using Libreria_Front.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Front_Musica.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUsuariosPresentacion IUsuariosPresentacion;
        private readonly IUsuarios_RolesPresentacion IUsuarios_RolesPresentacion;
        private readonly IRolesPresentacion IRolesPresentacion;
        private readonly IRoles_PermisosPresentacion IRoles_PermisosPresentacion;
        private readonly IPermisosPresentacion IPermisosPresentacion;

        public IndexModel(IUsuariosPresentacion IUsuariosPresentacion,
                            IUsuarios_RolesPresentacion IUsuarios_RolesPresentacion,
                            IRolesPresentacion IRolesPresentacion,
                            IRoles_PermisosPresentacion IRoles_PermisosPresentacion,
                            IPermisosPresentacion IPermisosPresentacion)
        {
            this.IUsuariosPresentacion = IUsuariosPresentacion;
            this.IUsuarios_RolesPresentacion = IUsuarios_RolesPresentacion;
            this.IRolesPresentacion = IRolesPresentacion;
            this.IRoles_PermisosPresentacion = IRoles_PermisosPresentacion;
            this.IPermisosPresentacion = IPermisosPresentacion;
        }
        public bool EstaLogueado = false;
        public bool MostrarRegistro { get; set; } = false;
        [BindProperty] public string? Email { get; set; }
        [BindProperty] public string? Contraseña { get; set; }
        [BindProperty] public string? NuevoNombre { get; set; }
        [BindProperty] public string? NuevoApellido { get; set; }
        [BindProperty] public string? NuevoCorreo { get; set; }
        [BindProperty] public string? NuevaContraseña { get; set; }

        public void OnGet()
        {
            EstaLogueado = Acceso.EstaLogueado(HttpContext);
        }
        public string? MensajeEstado { get; set; }

        public void OnPostBtMostrarRegistro()
        {
            MostrarRegistro = true;
            EstaLogueado = Acceso.EstaLogueado(HttpContext);
        }

        public void OnPostBtVolverLogin()
        {
            MostrarRegistro = false;
            EstaLogueado = Acceso.EstaLogueado(HttpContext);
        }

        public void OnPostBtRegistrar()
        {
            try
            {
                EstaLogueado = Acceso.EstaLogueado(HttpContext);

                if (string.IsNullOrWhiteSpace(NuevoNombre) ||
                    string.IsNullOrWhiteSpace(NuevoApellido) ||
                    string.IsNullOrWhiteSpace(NuevoCorreo) ||
                    string.IsNullOrWhiteSpace(NuevaContraseña))
                {
                    MostrarRegistro = true;
                    MensajeEstado = "Completa nombre, apellido, correo y contraseña.";
                    return;
                }

                var hasher = new PasswordHasher<string>();
                var nuevoUsuario = new Usuarios
                {
                    Nombre = NuevoNombre.Trim(),
                    Apellido = NuevoApellido.Trim(),
                    Correo = NuevoCorreo.Trim(),
                    ContrasenaHash = hasher.HashPassword(NuevoCorreo.Trim(), NuevaContraseña),
                    Fecha_Registro = DateTime.Now
                };

                var usuarioCreado = this.IUsuariosPresentacion.Insertar(nuevoUsuario);

                // Asignar rol por defecto en Usuarios_Roles (por ejemplo "Consulta")
                var roles = this.IRolesPresentacion.Consultar();
                var rolDefecto = roles.FirstOrDefault(r =>
                    string.Equals(r.Nombre, "Consulta", StringComparison.OrdinalIgnoreCase));

                if (usuarioCreado != null && usuarioCreado.Id > 0 && rolDefecto != null)
                {
                    this.IUsuarios_RolesPresentacion.Insertar(new Usuarios_Roles
                    {
                        Usuario = usuarioCreado.Id,
                        Rol = rolDefecto.Id
                    });
                }

                NuevoNombre = string.Empty;
                NuevoApellido = string.Empty;
                NuevoCorreo = string.Empty;
                NuevaContraseña = string.Empty;
                MostrarRegistro = false;
                MensajeEstado = "Usuario creado correctamente. Ya puedes iniciar sesión.";
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtClean()
        {
            try
            {
                Email = string.Empty;
                Contraseña = string.Empty;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtEnter()
        {
            try
            {
                if (string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Contraseña))
                {
                    OnPostBtClean();
                    return;
                }

                var usuarios = this.IUsuariosPresentacion.Consultar();
                var usuario = usuarios.FirstOrDefault(u =>
                    string.Equals(u.Correo, Email?.Trim(), StringComparison.OrdinalIgnoreCase));

                if (usuario == null || string.IsNullOrEmpty(usuario.ContrasenaHash) || string.IsNullOrEmpty(Contraseña))
                {
                    OnPostBtClean();
                    MensajeEstado = "Usuario o contraseña incorrectos.";
                    return;
                }

                bool contraseñaValida;
                var hasher = new PasswordHasher<string>();

                // Soporta hashes generados por PasswordHasher y también valores planos iniciales si aún no se han hasheado
                if (usuario.ContrasenaHash.StartsWith("AQAAAA"))
                {
                    var verificacion = hasher.VerifyHashedPassword(usuario.Correo!, usuario.ContrasenaHash, Contraseña);
                    contraseñaValida = verificacion == PasswordVerificationResult.Success ||
                                       verificacion == PasswordVerificationResult.SuccessRehashNeeded;
                }
                else
                {
                    contraseñaValida = usuario.ContrasenaHash == Contraseña;
                }

                if (!contraseñaValida)
                {
                    OnPostBtClean();
                    MensajeEstado = "Usuario o contraseña incorrectos.";
                    return;
                }

                var usuariosRoles = this.IUsuarios_RolesPresentacion.Consultar()
                    .Where(ur => ur.Usuario == usuario.Id)
                    .ToList();

                var roles = this.IRolesPresentacion.Consultar();
                var rolesUsuario = usuariosRoles
                    .Join(roles, ur => ur.Rol, r => r.Id, (ur, r) => r)
                    .ToList();

                var idsRoles = rolesUsuario.Select(r => r.Id).ToHashSet();
                var nombresRoles = string.Join(",", rolesUsuario.Select(r => r.Nombre));

                var rolesPermisos = this.IRoles_PermisosPresentacion.Consultar()
                    .Where(rp => idsRoles.Contains(rp.Rol))
                    .ToList();

                var permisos = this.IPermisosPresentacion.Consultar();
                var codigosPermisos = rolesPermisos
                    .Join(permisos, rp => rp.Permiso, p => p.Id, (rp, p) => p.Codigo)
                    .Where(c => !string.IsNullOrWhiteSpace(c))
                    .Distinct();

                HttpContext.Session.SetString("Usuario", usuario.Correo!);
                HttpContext.Session.SetString("Rol", nombresRoles);
                HttpContext.Session.SetString("Permisos", string.Join(",", codigosPermisos));

                EstaLogueado = true;
                MensajeEstado = null;
                OnPostBtClean();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtClose()
        {
            try
            {
                HttpContext.Session.Clear();
                HttpContext.Response.Redirect("/");
                EstaLogueado = false;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
