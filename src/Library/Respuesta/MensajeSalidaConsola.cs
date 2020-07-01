using System;
using System.Threading.Tasks;
using Telegram.Bot.Examples.Echo;

namespace Library
{
    public class MensajeSalidaConsola : MensajeSalida
    {
        private string imagen;

        public MensajeSalidaConsola (string cont, long num) : base (cont, num)
        {

        }

        public override Task EnviarImagen(string ruta)
        {
            throw new NotImplementedException();
        }

        public override Task EnviarTexto ()
        {
            Console.WriteLine (this.Contenido);
            return Task.CompletedTask;

        }
    }
}