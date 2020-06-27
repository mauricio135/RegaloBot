using System;
using Telegram.Bot.Examples.Echo;

namespace Library
{
    public class BandejaSalida
    {
        public static async void EnviarMensaje (MensajeSalida mensaje)
        {
            mensaje.EnviarTexto ();

           
        }
        public static  void EnviarGif (MensajeSalida mensaje ,string UrlGif)
        {           
            if (mensaje.Id != 0)
            {
                MensajeSalidaTelegram men;
                men = (MensajeSalidaTelegram) mensaje;
                men.EnviarGif (UrlGif);

            }

        }

    }
}