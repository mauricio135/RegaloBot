using System.Collections.Generic;

namespace Library
{
    public interface ITienda
    {
        List<Regalo> BuscarRegalo(string busqueda);
    }
}