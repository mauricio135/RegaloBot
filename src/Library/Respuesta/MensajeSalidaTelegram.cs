using System.Threading.Tasks;
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
        public async override Task EnviarTexto ()
        {
            await TelegramAPI.Contestar (this.Id, this.Contenido);
          //  await TelegramAPI.Contestar2 (this.Id, this.Contenido);            
            
           // await TelegramAPI.SendInlineKeyboard(this.Id);
            
        }
        public override async Task EnviarImagen (string url)
        {

            await TelegramAPI.EnviarFoto (this.Id, url);
        }
        public async Task EnviarGif (string url)
        {

            await TelegramAPI.EnviarGif (this.Id, url);
        }

    }
}