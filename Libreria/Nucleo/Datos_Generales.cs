namespace Libreria.Nucleo
{
    public class Datos_Generales
    {
        public static string ObtenerStringConexion()
        {
            //Usar el que convenga según su versión de SQL Server
            return "server=localhost;database=bd_Biblioteca_Musical;Integrated Security=True;TrustServerCertificate=true;";
            //return "server=localhost\\DEV;database=bd_Biblioteca_Musical;Integrated Security=True;TrustServerCertificate=true;";
        }
    }
}
