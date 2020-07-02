using System;
using System.Collections.Generic;
using PII_MLApi;

namespace Library
{
    public class PipeHogar: PipeFinal
    {
        private static List<string> indefinido = new List<string>
        {
            "1592-bazar_y_cocina", "436298-almacenamiento_y_organizacion",
            "436440-cuadros__carteles_y_espejos", "436380-muebles_para_el_hogar"
        };
        private static List<string> masculino = new List<string>
        {
            "164461-herramientas", "202390-accesorios_de_interior", "202842-cajas_y_organizadores",
            "8232-flippers_y_arcade"

        };
        private static List<string> femenino = new List<string>
        {
            "1631-adornos_y_decoracion_del_hogar", "1609-ropa_de_cama", "436273-utensilios_de_preparacion"
            
        };
        public PipeHogar()
        {
            var random = new Random();
            int indice = random.Next(indefinido.Count);
            this.categoria = indefinido[indice];
        }
        public override string Filtrar(Perfil persona)
        {
            List<string> posibles = new List<string>();
            foreach (string link in indefinido)
            {
                posibles.Add(link);
            }
            if (persona.Genero == TipoGenero.Masculino)
            {
                foreach (string link in masculino)
                {
                    posibles.Add(link);
                }
            }
            else if (persona.Genero == TipoGenero.Femenino)
            {
                foreach (string link in femenino)
                {
                    posibles.Add(link);
                }
            }
            var random = new Random ();
            int indiceCat = random.Next(posibles.Count);
            this.categoria = posibles[indiceCat];

            List<string> tendencias = MLApi.SearchTendencias(this.categoria);
            
            int indice = random.Next(tendencias.Count);
            return tendencias[indice];
        }
    }
}