using System.Collections.Generic;
namespace Library
{
    public interface IProcesadorSugerencias
    {
        List<Regalo> ProcesarRegalos(List<Regalo> regalos);
    }
}