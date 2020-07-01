using System.Threading.Tasks;

namespace Library
{
    public abstract class MensajeSalida
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
        public MensajeSalida (string cont, long num)
        {
            this.id = num;
            this.contenido = cont;
        }
        public abstract Task EnviarTexto();
        public  abstract  Task EnviarImagen(string ruta);
       

    }
}