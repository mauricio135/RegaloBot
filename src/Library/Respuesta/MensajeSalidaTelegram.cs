namespace Library
{
    public class MensajeSalidaTelegram: MensajeSalida
    {
        private string imagen;

        public MensajeSalidaTelegram(string cont, long num) : base(cont, num)
        {
        }

        public string Imagen
        {
            get => imagen;
            set => imagen = value;
        }
    }
}