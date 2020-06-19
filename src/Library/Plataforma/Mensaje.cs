namespace Library
{
    public class Mensaje
    {
        private string contenido;
        private long id;
        public string Contenido 
        {
            get => contenido;
            set => contenido = value;
        }

        public long Id 
        {
            get => id;
            set => id = value;
        }

        public Mensaje (string cont, long num)
        {
            this.contenido = cont;
            this.id = num;
        }
    }
}