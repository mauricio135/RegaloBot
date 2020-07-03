using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Clase abstracta que representa los mensajes que envía el bot hacia el usuario 
    /// </summary>
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
        public abstract Task EnviarReaccion();
       

    }
}