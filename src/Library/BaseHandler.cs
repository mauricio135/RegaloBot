using System;
using System.Collections.Generic;

namespace Library
{
    public abstract class  BaseHandler: IHandler
    {
        //Lista que contiene los números de ID a los que se ha consultado acerca de este parámetro.
        //Se utiliza para controlar el flujo de COR.
        protected List<long> UsuariosPreguntados = new List<long>();
        public IHandler Siguiente { get; set; }

        public virtual void Handle(Mensaje m)
        {
            if (this.Siguiente != null)
            {
                this.Siguiente.Handle(m);
            }
        }
        public abstract void Preguntar(long id);
        
    }
}