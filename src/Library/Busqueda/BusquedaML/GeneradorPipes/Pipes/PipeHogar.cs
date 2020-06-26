using System;
using System.Collections.Generic;
namespace Library
{
    public class PipeHogar: PipeFinal
    {
        private static List<string> categorias = new List<string>
        {"1574-hogar__muebles_y_jardin", "164461-herramientas",
        "438284-pequenos_electrodomesticos", "1367-antiguedades_y_colecciones"
        };
        public PipeHogar()
        {
            var random = new Random();
            int indice = random.Next(categorias.Count);
            this.categoria = categorias[indice];
        }
    }
}