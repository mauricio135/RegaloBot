using System;
using Telegram.Bot.Examples.Echo;

namespace Library
{
    public class BandejaSalida
    {
        public static void EnviarMensaje (MensajeSalida mensaje)
        {
            mensaje.EnviarTexto ();

            if (mensaje.Id != 0)
            {

                MensajeSalidaTelegram men;
                men = (MensajeSalidaTelegram) mensaje;

                if (men.Imagen != null)
                {
                    mensaje.EnviarImagen (@"C:\Users\FIT\repos\RegaloBot\src\Library\Respuesta\foto.webp");

                }

            }
            // 

            // } 
            //  mensaje.Enviar......();              

        }

    }
}