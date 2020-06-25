using Telegram.Bot.Examples.Echo;

namespace Library
{
    public class MensajeSalidaTelegram: MensajeSalida
    {
        private string imagen;

        public MensajeSalidaTelegram(string cont, long num) : base(cont, num)
        {
          TelegramAPI.Contestar (num, cont);
        }

        public string Imagen
        {
            get => imagen;
            set => imagen = value;
        }
    }
}