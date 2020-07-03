using System;
using System.Collections.Generic;
using PII_MLApi;

namespace Library
{
    /// <summary>
    /// Pipe que se encarga de las sugerencias del área de TiempoLibre
    /// </summary>
    public class PipeTiempoLibre: PipeFinal
    {
        /// <summary>
        /// Listado de categorías de elementos relacionados al tiempo libre que pueden contener regalos adecuados para todos los géneros
        /// </summary>
        /// <value></value>
        private static List<string> indefinido = new List<string> 
        {
            "1285-futbol",  "3697-auriculares", "377642-ukeleles",
            "2987-guitarras", "3004-baterias_y_percusion", "6159-juegos_de_salon"

        };
        /// <summary>
        /// Listado de categorías de elementos relacionados al tiempo libre que pueden contener regalos adecuados para niños
        /// </summary>
        /// <value></value>
        private static List<string> infancia = new List<string>
        {
            "1132-juegos_y_juguetes", "1153-electronicos_para_ninos", "433060-casas_y_carpas_para_ninos", "1166-peluches"
        };
        /// <summary>
        /// Listado de categorías de elementos relacionados al tiempo libre que pueden contener regalos adecuados para adultos
        /// </summary>
        /// <value></value>
        private static List<string> adulto = new List<string>
        {
            "65829-aparatos_de_musculacion", "432988-juegos_de_mesa_y_cartas", "110944-juguetes_antiestres_e_ingenio",
            "1174-musica", "1799-historietas_y_comics"

        };
        /// <summary>
        /// Listado de categorías de elementos relacionados al tiempo libre que pueden contener regalos adecuados para hombres
        /// </summary>
        /// <value></value>

        private static List<string> masculino = new List<string> 
        {
            "1144-consolas_y_videojuegos", "433624-tablets_y_accesorios"
        };
        /// <summary>
        /// Listado de categorías de elementos relacionados al tiempo libre que pueden contener regalos adecuados para mujeres
        /// </summary>
        /// <value></value>

        private static List<string> femenino = new List<string> 
        {
            "206291-funcional__pilates_y_yoga", 

        };
        public PipeTiempoLibre()
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
            if (persona.Edad < 12)
            {
                foreach (string link in infancia)
                {
                    posibles.Add(link);
                }
            }
            else
            {
                foreach (string link in adulto)
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