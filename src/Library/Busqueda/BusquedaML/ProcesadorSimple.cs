using System.Collections.Generic;
using System;

namespace Library
{
    public class ProcesadorSimple : IProcesadorSugerencias
    {
        public List<Regalo> ProcesarRegalos(List<Regalo> regalos)
        {
            List <Regalo> resultado = new List<Regalo>();
            var random = new Random();
            int indice = random.Next(regalos.Count);
            resultado.Add(regalos[indice]);
            return resultado;
        }
    }
}