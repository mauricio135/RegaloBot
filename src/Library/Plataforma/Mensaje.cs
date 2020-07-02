namespace Library
{
    public class Mensaje
    {
        private string contenido;
        private long id;
        private TipoPlataforma plataforma;
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
        public TipoPlataforma Plataforma
        {
            get => plataforma;
            set => plataforma = value;
        }

        public Mensaje (string cont, long num ,TipoPlataforma plat)
        {
            this.contenido = cont;
            this.id = num;
            this.plataforma = plat;
        }
    }
}