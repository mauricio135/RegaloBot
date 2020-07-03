using System.Collections.Generic;

namespace Library
{
    public abstract class PipeCondicional : IPipe
    {
        protected List<IPipe> caminos;
        public abstract string Filtrar(Perfil persona);
    }
}