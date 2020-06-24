using System.Collections.Generic;
namespace Library
{
    public interface IProcesadorSugerencias
    {
        List<string> ProcesarRegalos(List<string> regalos);
    }
}