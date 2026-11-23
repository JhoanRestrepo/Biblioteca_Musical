namespace Front_Musica.Utilidades
{
    public static class Acceso
    {
        public static bool EstaLogueado(HttpContext context)
        {
            return !string.IsNullOrEmpty(context.Session.GetString("Usuario"));
        }

        public static string ObtenerRol(HttpContext context)
        {
            return context.Session.GetString("Rol") ?? string.Empty;
        }

        public static bool TienePermiso(HttpContext context, string codigoPermiso)
        {
            if (!EstaLogueado(context))
                return false;

            if (string.Equals(ObtenerRol(context), "Administrador", StringComparison.OrdinalIgnoreCase))
                return true;

            var permisos = context.Session.GetString("Permisos") ?? string.Empty;
            var lista = permisos.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            return lista.Contains(codigoPermiso);
        }
    }
}

