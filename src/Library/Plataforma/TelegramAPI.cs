using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Library;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Examples.Echo
{
    public class TelegramAPI
    {
        /// <summary>
        /// La instancia del bot.
        /// </summary>
        private static TelegramBotClient Bot;

        /// <summary>
        /// El token provisto por Telegram al crear el bot.
        /// </summary>
        private static string Token = "1028487705:AAFJ_hNrtFc2T4xhdIC4MYUZlXHBmVWfkaQ";

        public static void IniciarTelegram ()
        {
            Bot = new TelegramBotClient (Token);
            var cts = new CancellationTokenSource ();

            Bot.StartReceiving (
                new DefaultUpdateHandler (HandleUpdateAsync, HandleErrorAsync),
                cts.Token

            );

            Console.WriteLine ($"Bot iniciado");
        }

        /// <summary>
        /// Maneja las actualizaciones del bot (todo lo que llega), incluyendo
        /// mensajes, ediciones de mensajes, respuestas a botones, etc. 
        /// </summary>
        /// <param name="update"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task HandleUpdateAsync (Update update, CancellationToken cancellationToken)
        {
            try
            {
                // sólo respondemos a mensajes de texto
                if (update.Type == UpdateType.Message)
                {
                    await HandleMessageReceived (update.Message);
                }
            }
            catch (Exception e)
            {
                await HandleErrorAsync (e, cancellationToken);
            }
        }

        /// <summary>
        /// Manejo de excepciones. 
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task HandleErrorAsync (Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine (exception.Message);
            return Task.CompletedTask;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">El mensaje recibido</param>
        /// <returns></returns>
        private static async Task HandleMessageReceived (Message message)
        {
            Console.WriteLine ($"Received a message from {message.From.FirstName} saying: {message.Text}");
            await Plataforma.RecibirMensaje (message.Text, message.Chat.Id ,TipoPlataforma.Telegram);
        }
        /// <summary>
        /// Método que envía un mensaje mediante Telegram
        /// </summary>
        /// <param name="id">Identificador de la conversación</param>
        /// <param name="respuesta">Contenido de la respuesta</param>
        /// <returns></returns>
        public static async Task Contestar (long id, string respuesta)
        {

            await Bot.SendTextMessageAsync (id, respuesta, ParseMode.Default);

        }
        /// <summary>
        /// Método que envía GIFs mediante Telegram
        /// </summary>
        /// <param name="id">Identificador de la conversación</param>
        /// <param name="gif">URL del link (provenientes de GIPHY.COM)</param>
        /// <returns></returns>
        public static async Task EnviarGif (long id, string gif)
        {
            await Bot.SendAnimationAsync (id, gif);
        }



    }
}