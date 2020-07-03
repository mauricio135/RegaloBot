using System;
using System.Collections.Generic;
using PII_MLApi;

namespace Library
{
    /// <summary>
    /// Pipe que se encarga de las sugerencias del área de Cuidado Personal
    /// </summary>
    public class PipeCuidadoPersonal: PipeFinal
    {
        /// <summary>
        /// Listado de categorías de elementos relacionados al cuidado personal que pueden contener regalos adecuados para todos los géneros
        /// </summary>
        /// <value></value>
        private static List<string> indefinido = new List<string>
        {
            "1271-perfumes_y_fragancias", "3937-joyas_y_relojes", "190943-equipaje_y_accesorios_de_viaje",
            "10217-masajes", "1456-lentes_de_sol"
        };
        /// <summary>
        /// Listado de categorías de elementos relacionados al cuidado personal que pueden contener regalos adecuados para hombres
        /// </summary>
        /// <value></value>
        private static List<string> masculino = new List<string>
        { 
            "417575-barberia", "431677-relojes", "158838-billeteras", "431993-morrales_y_portafolios",
            "431991-accesorios", "158807-corbatas"

        };
        /// <summary>
        /// Listado de categorías de elementos relacionados al cuidado personal que pueden contener regalos adecuados para mujeres
        /// </summary>
        /// <value></value>
        private static List<string> femenino = new List<string>
        {
            "1248-maquillaje", "430281-enteros__bikinis_y_trikinis", "190940-carteras",
            "191213-monederos", "190994-mochilas", "442711-chales_y_chalinas"
        };
        public PipeCuidadoPersonal()
        {
            
            var random = new Random();
            int indice = random.Next(indefinido.Count);
            this.categoria = indefinido[indice];
        }
        /// <summary>
        /// Dependiendo de las características de la persona que recibe el obsequio, agrega categorías a la lista de la cual luego se extraerá un valor aleatorio para buscar
        /// </summary>
        /// <param name="persona">Perfil de la persona objetivo</param>
        /// <returns></returns>
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