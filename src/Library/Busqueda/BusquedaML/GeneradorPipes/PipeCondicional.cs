using System.Collections.Generic;

namespace Library
{
    public class PipeCondicional : IPipe
    {
        protected List<IPipe> caminos;
        public virtual string Filtrar(Perfil persona)
        {
            return "";
        }
    }
}