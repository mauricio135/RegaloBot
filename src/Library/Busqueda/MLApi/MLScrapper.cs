using System;
using System.Collections.Generic;
using AngleSharp;
using AngleSharp.Dom;
using System.Threading.Tasks;

namespace PII_MLApi
{
    /// <summary>
    /// Ejecuta una búsqueda en ML de Uruguay y parsea el HTML
    /// de respuesta para construir la lista de resultados.
    /// </summary>
    internal class MLScrapper
    {
        private string url;

        internal MLScrapper(string query)
        {
            this.url = $"https://listado.mercadolibre.com.uy/{query}";
        }

        /// <summary>
        /// Ejecuta la búsqueda y retorna los resultados.
        /// </summary>
        /// <returns>Lista de objetos resultado.</returns>
        public virtual async Task<List<MLApiSearchResult>> Scrape()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(this.url);
            return Parse(document);
        }

        /// <summary>
        /// Parsea el HTML de respuesta para construir la lista de objetos
        /// resultado.
        /// </summary>
        /// <param name="document">El HTML de respuesta de ML.</param>
        /// <returns>Lista de objetos resultado.</returns>
        protected virtual List<MLApiSearchResult> Parse(AngleSharp.Dom.IDocument document)
        {
            List<MLApiSearchResult> results = new List<MLApiSearchResult>();

            foreach(var item in document.QuerySelectorAll("#searchResults li.results-item"))
            {
                try
                {
                    string title = item.QuerySelector(".item__title span.main-title").InnerHtml.Trim();
                    string price = item.QuerySelector(".item__price > .price__fraction").InnerHtml.Trim();
                    string currency = item.QuerySelector(".item__price > .price__symbol").InnerHtml.Trim();
                    string itemURL;
                    string imageURL;

                    IElement itemLink = item.QuerySelector(".item__title > a");
                    if (itemLink == null)
                    {
                        itemLink = item.QuerySelector(".item__info-link");
                    }
                    itemURL = itemLink.GetAttribute("href").Trim();

                    IElement image = item.QuerySelector(".item__image img");
                    if (!String.IsNullOrEmpty(image.GetAttribute("src")))
                    {
                        imageURL = image.GetAttribute("src").Trim();
                    }
                    else
                    {
                        imageURL = image.GetAttribute("data-src").Trim();
                    }

                    results.Add(new MLApiSearchResult(title, price, currency, imageURL, itemURL));
                }
                catch(NullReferenceException) { }
            }

            return results;
        }

        /// <summary>
        /// Parsea el HTML de respuesta para construir la lista de objetos
        /// resultado.
        /// </summary>
        /// <param name="document">El HTML de respuesta de ML.</param>
        /// <returns>Lista de objetos resultado.</returns>
        protected virtual List<string> ParseTendencias(AngleSharp.Dom.IDocument document)
        {
            List<string> results = new List<string>();

            foreach(var item in document.QuerySelectorAll("li.searches__item"))
            {
                try
                {
                    string title = item.QuerySelector("a").InnerHtml.Trim();
                    results.Add(title);
                }
                catch(NullReferenceException) { }
            }

            return results;
        }

        public virtual async Task<List<string>> ScrapeTendencias(string categoria)
        {
            this.url = $"https://tendencias.mercadolibre.com.uy/{categoria}";
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(this.url);
            return ParseTendencias(document);
        }

    }
}
