using System;
using System.Threading.Tasks;
using Telegram.Bot.Examples.Echo;
namespace Library
{
    public class Bot
    {
        public static async void IniciarBot ()
        {
            TelegramAPI.IniciarTelegram ();
            var con = Consola.IniciarConsolaAsync ();

            string cont = await con;

        }

    }
}