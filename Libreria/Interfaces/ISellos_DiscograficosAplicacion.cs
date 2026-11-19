using Libreria.Entidades;

namespace Libreria.Interfaces
{
    public interface ISellos_DiscograficosAplicacion
    {
        Sellos_Discograficos Insertar(Sellos_Discograficos entidad);
        Sellos_Discograficos Actualizar(Sellos_Discograficos entidad);
        List<Sellos_Discograficos> Consultar();
        List<Sellos_Discograficos> Buscar(Sellos_Discograficos entidad);
        Sellos_Discograficos Borrar(Sellos_Discograficos entidad);

    }
}