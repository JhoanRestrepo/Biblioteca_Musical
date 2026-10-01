using Libreria.Implementaciones;
using Libreria.Interfaces;

try
{
    IConexion conexion = new Conexion();
    conexion.StringConexion = "server=localhost;database=bd_Biblioteca_Musical;Integrated Security=True;TrustServerCertificate=true;";
    //conexion.StringConexion = "server=localhost\\DEV;database=bd_Biblioteca_Musical;Integrated Security=True;TrustServerCertificate=true;";
    var lista_albumes = conexion.Albumes!.ToList();
    
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

Console.WriteLine("presentacion_consola");
