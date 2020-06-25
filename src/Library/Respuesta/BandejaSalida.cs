using System;
using Telegram.Bot.Examples.Echo;

namespace Library
{
    public class BandejaSalida
    { 
        public static void EnviarMensaje (MensajeSalida mensaje)
        {
            mensaje.EnviarTexto();
           // mensaje.EnviarImagen(); 
          //  mensaje.EnviarEmoticon();              

        }

    }
}