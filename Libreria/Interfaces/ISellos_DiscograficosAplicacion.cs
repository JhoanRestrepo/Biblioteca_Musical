using Libreria.Entidades;

namespace Libreria.Interfaces
{
    public interface ISellos_DiscograficosAplicacion
    {
        Sellos_Discograficos Insertar(Sellos_Discograficos entidad);
        Sellos_Discograficos Actualizar(Sellos_Discograficos entidad);
        List<Sellos_Discograficos> Consultar();
        Sellos_Discograficos Borrar(Sellos_Discograficos entidad);
    }
}