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
            await Plataforma.RecibirMensaje (message.Text, message.Chat.Id ,TipoPlataforma.Telegram);
        }

        public static async Task Contestar (long id, string respuesta)
        {

            await Bot.SendTextMessageAsync (id, respuesta, ParseMode.Default);

        }
      

         public  static async Task SendInlineKeyboard(long id )
            {
                await Bot.SendChatActionAsync(id, ChatAction.Typing);

                // Simulate longer running task
                await Task.Delay(500);

                var inlineKeyboard = new InlineKeyboardMarkup(new[]
                {
                    // first row
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("1.1", "11"),
                        InlineKeyboardButton.WithCallbackData("1.2", "12"),
                    },
                    // second row
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("2.1", "21"),
                        InlineKeyboardButton.WithCallbackData("2.2", "22"),
                    }
                });
                await Bot.SendTextMessageAsync(
                    chatId: id,
                    text: "Choose",
                    replyMarkup: inlineKeyboard
                );
            }

           public static async Task SendReplyKeyboard(long id)
            {
                var replyKeyboardMarkup = new ReplyKeyboardMarkup(
                    new KeyboardButton[][]
                    {
                        new KeyboardButton[] { "Hombre", "Mujer" },
                        new KeyboardButton[] { "No te interesa" },
                    },
                    resizeKeyboard: true
                );
                   await Bot.SendTextMessageAsync(
                    chatId: id,
                    text: "Por favor selecciona una opción",
                    replyMarkup: replyKeyboardMarkup

                );
            }



        public static async Task EnviarGif (long id, string gif)
        {

            await Bot.SendAnimationAsync (id, gif);

        }



    }
}