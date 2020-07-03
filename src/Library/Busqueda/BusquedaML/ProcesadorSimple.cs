using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Por SRP, la única razón de cambio de esta clase es que se decida procesar las sugerencias siguiendo otros parámetros.
    /// Por Expert, se le asigna esta responsabilidad, ya que conoce toda la lista de Regalo.
    /// </summary>
    public class ProcesadorSimple : IProcesadorSugerencias
    {
        public Regalo ProcesarRegalos (List<Regalo> regalos, int precioMin, int precioMax)
        {
            List<Regalo> resultado = new List<Regalo> ();
            var random = new Random ();

            foreach (Regalo regalo in regalos)
            {
                try
                {
                    if (Int32.Parse (regalo.Precio) < precioMax && Int32.Parse (regalo.Precio) > precioMin)
                    {
                        resultado.Add (regalo);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine ("No se pudo Parsear el precio, tomando otro elemento");

                }

            }
            if (resultado.Count == 0)
            {
                throw new NullReferenceException();
            }

            int indice = random.Next (resultado.Count);

            return resultado[indice];
        }
    }
}