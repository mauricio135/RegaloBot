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
        public override string Filtrar(Perfil persona)
        {
            if (persona.Edad > 30 && persona.Edad < 60 && persona.Genero == TipoGenero.Masculino)
            {
                return "164461-herramientas";
            }
            else if (persona.Edad > 50)
            {
                return "436246-textiles_de_hogar_y_decoracion";
            }
            else if (persona.Edad > 30 && persona.Edad < 60 && persona.Genero == TipoGenero.Femenino)
            {
                return "1621-jardin_y_exterior";
            }
            else if (persona.Edad < 40)
            {
                return "438284-pequenos_electrodomesticos";
            }
            else
            {
                return "1574-hogar__muebles_y_jardin";
            }
        }
    }
}