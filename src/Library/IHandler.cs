namespace Library
{
    public interface IHandler
    {
        IHandler Siguiente { set; }

        void Handle(Mensaje m);

        void Preguntar();
    }
}