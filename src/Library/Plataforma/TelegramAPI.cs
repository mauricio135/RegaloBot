using System;
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

        public static async Task IniciarTelegram ()
        {
            Bot = new TelegramBotClient (Token);
            var cts = new CancellationTokenSource ();

            Bot.StartReceiving (
                new DefaultUpdateHandler (HandleUpdateAsync, HandleErrorAsync),
                cts.Token

            );

            Console.WriteLine ($"Bot iniciado");
            // Esperamos a que el usuario aprete Enter en la consola para terminar el bot.
            //Console.ReadLine();
        }

        /// <summary>
        /// Maneja las actualizaciones del bot (todo lo que llega), incluyendo
        /// mensajes, ediciones de mensajes, respuestas a botones, etc. En este
        /// ejemplo sólo manejamos mensajes de texto.
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
        /// Por ahora simplemente la imprimimos en la consola.
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
            await Plataforma.RecibirMensaje (message.Text, message.Chat.Id);
        }

        public static async void Contestar (long id, string respuesta)
        {
            await Bot.SendTextMessageAsync (id, respuesta);
      
        }
         public static async Task EnviarGif (long id, string gif)
        {
           // await Bot.SendVideoAsync (id, gif);
             await Bot.SendAnimationAsync (id, gif);


        }

        public static async Task EnviarFoto (long id, string ruta)
        {
            await Bot.SendChatActionAsync (id, ChatAction.UploadPhoto);

            string filePath = ruta;
            var fileStream = new FileStream (filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            var fileName = filePath.Split (Path.DirectorySeparatorChar).Last ();
            await Bot.SendPhotoAsync (
                chatId: id,
                photo: new InputOnlineFile (fileStream, fileName),
                caption: "te gusta?"
            );
        }
        

    }
}