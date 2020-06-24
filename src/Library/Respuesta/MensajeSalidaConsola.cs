using Telegram.Bot.Examples.Echo;
using System;

namespace Library
{
    public class MensajeSalidaConsola: MensajeSalida
    {
        private string imagen;

        public MensajeSalidaConsola(string cont, long num) : base(cont, num)
        {
         Console.WriteLine(cont);
        }
   }
}