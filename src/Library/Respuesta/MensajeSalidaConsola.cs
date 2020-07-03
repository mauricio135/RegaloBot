using System;
using System.Threading.Tasks;
using Telegram.Bot.Examples.Echo;

namespace Library
{
    /// <summary>
    /// Como ejemplo de reutilización de código, MensajeSalidaConsola hereda de MensajeSalida
    /// </summary>
    public class MensajeSalidaConsola : MensajeSalida
    {

        public MensajeSalidaConsola (string cont, long num) : base (cont, num)
        {

        }
        /// <summary>
        /// Aplicando polimorfismo, EnviarTexto para MensajeSalidaConsola aplica su propio método para comunicarse
        /// mediante esta plataforma
        /// </summary>
        /// <returns></returns>
        public override Task EnviarTexto ()
        {
            Console.WriteLine (this.Contenido);
            return Task.CompletedTask;

        }
        /// <summary>
        /// Aplicando polimorfismo, EnviarReaccion para MensajeSalidaConsola aplica su propio método para comunicarse
        /// mediante esta plataforma
        /// </summary>
        /// <returns></returns>
        public override Task EnviarReaccion ()
        {
            Console.WriteLine ("No lo sé Rick, parece falso...");
            return Task.CompletedTask;
        }

    }
}