using System.Collections.Generic;
namespace Library
{
    public interface IProcesadorSugerencias
    {
        Regalo ProcesarRegalos(List<Regalo> regalos,int precioMin, int precioMax);
    }
}