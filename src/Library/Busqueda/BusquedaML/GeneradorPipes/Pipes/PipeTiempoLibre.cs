using System;
using System.Collections.Generic;
namespace Library
{
    public class PipeTiempoLibre: PipeFinal
    {
        private static List<string> categorias = new List<string> 
        {"1276-deportes_y_fitness", "1144-consolas_y_videojuegos",
        "1039-camaras_y_accesorios", "1132-juegos_y_juguetes",
        "442458-libros__revistas_y_comics", "1168-musica_y_peliculas"};
        public PipeTiempoLibre()
        {
            var random = new Random();
            int indice = random.Next(categorias.Count);
            this.categoria = categorias[indice];
        }
        public override string Filtrar(Perfil persona)
        {
            if (persona.Edad < 10)
            {
                return "1132-juegos_y_juguetes";
            }
            else if (persona.Edad < 20 && persona.Genero == TipoGenero.Masculino)
            {
                return "1144-consolas_y_videojuegos";
            }
            else if (persona.Edad < 20 && persona.Genero == TipoGenero.Femenino)
            {
                return "164597-articulos_escolares";
            }
            else
            {
                return "1276-deportes_y_fitness";
            }

        }
    }
}