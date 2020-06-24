using System.Collections.Generic;
using PII_MLApi;
namespace Library
{
    public class MercadoLibre : ITienda
    {
        private MLApi acceso = new MLApi();
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