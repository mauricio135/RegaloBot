using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Clase abstracta de la que heredan los componentes del patrón Chain of Responsibility
    /// </summary>
    public abstract class  BaseHandler: IHandler
    {
        public IHandler Siguiente { get; set; }

        public virtual void Handle(Mensaje m)
        {
            if (this.Siguiente != null)
            {
                this.Siguiente.Handle(m);
            }
        }
        public abstract Task Preguntar(long id, TipoPlataforma plataforma);
        
    }
}