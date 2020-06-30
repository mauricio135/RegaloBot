using System.Collections.Generic;
using System;

namespace Library
{
    public class ProcesadorSimple : IProcesadorSugerencias
    {
        public List<Regalo> ProcesarRegalos(List<Regalo> regalos, int precioMin, int precioMax)
        {
            List <Regalo> resultado = new List<Regalo>();
            var random = new Random();

            while (resultado.Count == 0)
            {
                int indice = random.Next(regalos.Count);
                if (Int32.Parse(regalos[indice].Precio) < precioMax && Int32.Parse(regalos[indice].Precio) > precioMin)
                {
                    resultado.Add(regalos[indice]);
                }
                
            }

            return resultado;
        }
    }
}