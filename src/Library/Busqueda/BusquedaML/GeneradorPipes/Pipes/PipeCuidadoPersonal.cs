using System;
using System.Collections.Generic;
namespace Library
{
    public class PipeCuidadoPersonal: PipeFinal
    {
        private static List<string> categorias = new List<string>
        {"1246-belleza_y_cuidado_personal", "436727-electrodomesticos_de_belleza",
        "3937-joyas_y_relojes", "431677-relojes"
        };
        public PipeCuidadoPersonal()
        {
            var random = new Random();
            int indice = random.Next(categorias.Count);
            this.categoria = categorias[indice];
        }
    }
}