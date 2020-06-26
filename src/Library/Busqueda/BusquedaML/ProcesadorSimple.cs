using System.Collections.Generic;

namespace Library
{
    public class ProcesadorSimple : IProcesadorSugerencias
    {
        public List<Regalo> ProcesarRegalos(List<Regalo> regalos)
        {
            List <Regalo> resultado = new List<Regalo>();
            resultado.Add(regalos[0]);
            return resultado;
        }
    }
}