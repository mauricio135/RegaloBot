using Telegram.Bot.Examples.Echo;

namespace Library
{
    public class MensajeSalidaTelegram : MensajeSalida
    {
        private string imagen;

        public MensajeSalidaTelegram (string cont, long num) : base (cont, num)
        {
            
        }

        public string Imagen
        {
            get => imagen;
            set => imagen = value;
        }
        public override void EnviarTexto ()
        {
            TelegramAPI.Contestar (this.Id, this.Contenido);
        }

    }
}