using System;
namespace Library
{
    public class BaseHandler: IHandler
    {
        public IHandler Siguiente { get; set; }

        public virtual void Handle(Mensaje m)
        {
            if (this.Siguiente != null)
            {
                this.Siguiente.Handle(m);
            }
        }
        public virtual void Preguntar()
        {
            Console.WriteLine("Pregunta");
        }
    }
}