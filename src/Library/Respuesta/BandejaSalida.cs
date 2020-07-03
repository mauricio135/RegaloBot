using System;
using System.Threading.Tasks;
using Telegram.Bot.Examples.Echo;

namespace Library
{
    /// <summary>
    /// Clase encargada de enviar los diferente tipos de mensajes a las plataformas. Por SRP, la única razón de cambio de esta clase es que se modifiquen los contenidos enviados
    /// </summary>
    public class BandejaSalida
    {
        /// <summary>
        /// Método asincrónico que se encarga de enviar mensajes de texto
        /// </summary>
        /// <param name="mensaje">Objeto Mensaje a enviar</param>
        /// <returns></returns>
        public static async Task EnviarMensaje (MensajeSalida mensaje)
        {
            await mensaje.EnviarTexto ();

        }
        /// <summary>
        /// Método asincrónico que se encarga de enviar reacciones (aplicando polimorfismo, varía según el tipo de MensajeSalida que se pasa por parámetro)
        /// </summary>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public static async Task EnviarReaccion (MensajeSalida mensaje)
        {

            await mensaje.EnviarReaccion ();

        }

    }
}