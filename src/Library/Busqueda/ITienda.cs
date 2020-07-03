using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Interfaz de Tienda (dado un término de búsqueda, debe retornar una lista de Regalo)
    /// </summary>
    public interface ITienda
    {
        List<Regalo> BuscarRegalo(string busqueda);
    }
}