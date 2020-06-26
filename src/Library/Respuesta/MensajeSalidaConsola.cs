using System;
using Telegram.Bot.Examples.Echo;

namespace Library
{
    public class MensajeSalidaConsola : MensajeSalida
    {
        private string imagen;

        public MensajeSalidaConsola (string cont, long num) : base (cont, num)
        {

        }

        public override void EnviarImagen(string ruta)
        {
            throw new NotImplementedException();
        }

        public override void EnviarTexto ()
        {
            Console.WriteLine (this.Contenido);
        }
    }
}