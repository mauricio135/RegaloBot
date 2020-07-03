using System.Collections.Generic;
using PII_MLApi;
namespace Library
{
    /// <summary>
    /// Por patrón Adapter, la clase MercadoLibre implementa la interfaz ITienda para facilitar los servicios de MLApi, convirtiendo los datos recibidos
    /// a información útil para el bot
    /// </summary>
    public class MercadoLibre : ITienda
    {
        private MLApi acceso = new MLApi();
        /// <summary>
        /// Aplicación de la API de ML para realizar una búsqueda
        /// </summary>
        /// <param name="busqueda">Término que se desea buscar</param>
        /// <returns>Lista de objetos Regalo que son encontrados</returns>
        public List<Regalo> BuscarRegalo(string busqueda)
        {
            List<Regalo> resultado = new List<Regalo>();
            List<MLApiSearchResult> buscados = acceso.Search(busqueda);
            foreach (MLApiSearchResult buscado in buscados)
            {
                resultado.Add(this.ResultToRegalo(buscado));
            }
            return resultado;
        }
        /// <summary>
        /// Por patrón Creator, la clase MercadoLibre crea instancias de Regalo porque utiliza objetos de este tipo de forma cercana al devolverlos en un método
        /// </summary>
        /// <param name="resultado">Objeto resultado de búsqueda</param>
        /// <returns>Objeto Regalo creado a partir de MLApiSearchResult</returns>
        private Regalo ResultToRegalo(MLApiSearchResult resultado)
        {
            Regalo regalo = new Regalo();
            regalo.Nombre = resultado.Title;
            regalo.Precio = resultado.Price;
            regalo.Moneda = resultado.Currency;
            regalo.Url = resultado.ResultURL;
            regalo.UrlImagen = resultado.ImageURL;
            return regalo;
        }
    }

}