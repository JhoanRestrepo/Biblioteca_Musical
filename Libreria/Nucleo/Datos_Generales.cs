namespace Libreria.Nucleo
{
    public class Datos_Generales
    {
        public static string ObtenerStringConexion()
        {
            
            /*
             * string nombreEquipo = Environment.MachineName;

            // O evaluar si estás en un entorno de desarrollo local genérico
            // Si el servidor cambia por máquina, puedes mapearlo aquí o usar LocalDB:

            return "Server=(localdb)\\MSSQLLocalDB;Database=bd_Biblioteca_Musical;Integrated Security=True;TrustServerCertificate=true;";
            */
            //Usar el que convenga según su versión de SQL Server
            return "server=localhost;database=bd_Biblioteca_Musical;Integrated Security=True;TrustServerCertificate=true;";

            //return Environment.GetEnvironmentVariable("StringConexion")!;
            //return "server=localhost\\DEV;database=bd_Biblioteca_Musical;Integrated Security=True;TrustServerCertificate=true;";
        }
    }
}
