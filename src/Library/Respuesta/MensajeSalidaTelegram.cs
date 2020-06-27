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
        public override async void EnviarImagen (string url)
        {

            await TelegramAPI.EnviarFoto (this.Id, url);
        }
        public async void EnviarGif (string url)
        {

            await TelegramAPI.EnviarGif (this.Id, url);
        }

    }
}