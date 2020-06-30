using System;
using System.Threading.Tasks;
using Telegram.Bot.Examples.Echo;

namespace Library
{
    public class BandejaSalida
    {
        public static async Task EnviarMensaje (MensajeSalida mensaje)
        {
           await mensaje.EnviarTexto ();

           
        }
        public static async Task EnviarGif (MensajeSalida mensaje ,string UrlGif)
        {           
            if (mensaje.Id != 0)
            {
                MensajeSalidaTelegram men;
                men = (MensajeSalidaTelegram) mensaje;
               await men.EnviarGif (UrlGif);

            }
          

        }

    }
}