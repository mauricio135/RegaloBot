using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot.Examples.Echo;

namespace Library
{
    /// <summary>
    /// Clase que Hereda de MensajeaSalida,fué creada para resolver el flujo de Mensajes hacia la Telegram.
    /// </summary>
    public class MensajeSalidaTelegram : MensajeSalida
    {
        /// <summary>
        /// Listado de links que contienen GIFs para enviar mediante Telegram
        /// </summary>
        /// <typeparam name="string"></typeparam>
        /// <returns></returns>
        private static List<string> confusion = new List<string> ()
        {

            "https://media.giphy.com/media/uN5iwZB2v2dH2/giphy.gif",
            "https://media.giphy.com/media/3o7btPCcdNniyf0ArS/giphy.gif",
            "https://media.giphy.com/media/eChf44Gyj2VrO/giphy.gif",
            "https://media.giphy.com/media/APqEbxBsVlkWSuFpth/giphy.gif",
            "https://media.giphy.com/media/xx60sEpNkUBAk/giphy.gif",
            "https://media.giphy.com/media/Vo6YaTLaSMGqI/giphy.gif",
            "https://media.giphy.com/media/vsZF2hC9cH0Mo/giphy.gif",
            "https://media.giphy.com/media/QE8hREXIgRXeo/giphy.gif",
            "https://media.giphy.com/media/E2WEi5K1QzPxK/giphy.gif",
            "https://media.giphy.com/media/xL7PDV9frcudO/giphy.gif",
            "https://media.giphy.com/media/1X7lCRp8iE0yrdZvwd/giphy.gif",
            "https://media.giphy.com/media/SxgTcq5TT93mo/giphy.gif",
            "https://media.giphy.com/media/91fEJqgdsnu4E/giphy.gif",
            "https://media.giphy.com/media/l3q2K5jinAlChoCLS/giphy.gif",
        };

        public MensajeSalidaTelegram (string cont, long num) : base (cont, num)
        {

        }
        /// <summary>
        /// Aplicando polimorfismo, EnviarTexto para MensajeSalidaTelegram aplica su propio método para comunicarse
        /// mediante esta plataforma
        /// </summary>
        /// <returns></returns>
        public async override Task EnviarTexto ()
        {
            await TelegramAPI.Contestar (this.Id, this.Contenido);

        }
        /// <summary>
        /// Aplicando polimorfismo, EnviarReaccion para MensajeSalidaTelegram aplica su propio método para comunicarse
        /// mediante esta plataforma
        /// </summary>
        /// <returns></returns>
        public override async Task EnviarReaccion ()
        {
            string url;
            var random = new Random ();
            int indice = random.Next (confusion.Count);
            url = confusion[indice];

            await TelegramAPI.EnviarGif (this.Id, url);
        }

    }
}