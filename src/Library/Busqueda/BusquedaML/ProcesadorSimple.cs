using System;
using System.Collections.Generic;

namespace Library
{
    public class ProcesadorSimple : IProcesadorSugerencias
    {
        public List<Regalo> ProcesarRegalos (List<Regalo> regalos, int precioMin, int precioMax)
        {
            List<Regalo> resultado = new List<Regalo> ();
            var random = new Random ();

            while (resultado.Count == 0)
            {

                int indice = random.Next (regalos.Count);
                
                 Console.WriteLine(regalos[indice].Nombre); 
                 Console.WriteLine(regalos[indice].Moneda); 
                 Console.WriteLine(regalos[indice].Precio);  
                try
                {

                    if (Int32.Parse (regalos[indice].Precio) < precioMax && Int32.Parse (regalos[indice].Precio) > precioMin)
                    {
                        resultado.Add (regalos[indice]);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("No se pudo Parsear el precio, tomando otro elemento");                    

                }

                }

                return resultado;
            }
        }
    }