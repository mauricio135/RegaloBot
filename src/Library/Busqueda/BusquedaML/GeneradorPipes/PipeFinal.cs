using System;
using System.Collections.Generic;
using PII_MLApi;
namespace Library
{
    public class PipeFinal : IPipe
    {
        protected string categoria = "";
        public virtual string Filtrar(Perfil persona)
        {
            List<string> tendencias = MLApi.SearchTendencias(this.categoria);
            var random = new Random ();
            int indice = random.Next(tendencias.Count);
            return tendencias[indice];
        }
    }
}