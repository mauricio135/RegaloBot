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
            "https://media.giphy.com/media/1X7lCRp8iE0yrdZvwd/giphy.gif"

        };
        private string imagen;

        public MensajeSalidaTelegram (string cont, long num) : base (cont, num)
        {

        }

        public string Imagen
        {
            get => imagen;
            set => imagen = value;
        }
        public async override Task EnviarTexto ()
        {
            await TelegramAPI.Contestar (this.Id, this.Contenido);

        }

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