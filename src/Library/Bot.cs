using Telegram.Bot.Examples.Echo;
namespace Library
{
    public class Bot
    {
        public async static void IniciarBot()
        {
           // Consola.IniciarConsola();
            await TelegramAPI.IniciarTelegram();
        }

    }
}