using System;
using System.Threading.Tasks;
using Telegram.Bot.Examples.Echo;

namespace Library
{
    public class BandejaSalida
    {
        /// <summary>
        /// Clase encargada de enviar los diferente tipos de mensajes a las plataformas.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <returns></returns>
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