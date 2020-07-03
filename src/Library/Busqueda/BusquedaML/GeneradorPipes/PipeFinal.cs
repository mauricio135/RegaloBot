using System;
using System.Collections.Generic;
using PII_MLApi;
namespace Library
{
    public abstract class PipeFinal : IPipe
    {
        protected string categoria = "";
        public abstract string Filtrar(Perfil persona);
    }
}