using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library
{
    public class Respuesta
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
        private static ILectorArchivos lectorArchivos;
        public static async Task GenerarRespuesta (string contenido, long id)
        {
            //string cont = BuscarFrase (archivo);
            MensajeSalida mensaje;

            switch (id)
            {
                case 0:
                    mensaje = new MensajeSalidaConsola (contenido, id);
                    break;

                default:
                    mensaje = new MensajeSalidaTelegram (contenido, id);

                    break;

            }

            await BandejaSalida.EnviarMensaje (mensaje);

        }
        public static async Task PedirAclaracion (long id)
        {
            string respuesta = "Ups, no te entendí, puedes volver a respoder?";

            MensajeSalida mensaje;

            switch (id)
            {
                case 0:
                    mensaje = new MensajeSalidaConsola (respuesta, id);
                    break;

                default:
                    mensaje = new MensajeSalidaTelegram (respuesta, id);

                    break;

            }
            string conf;
            var random = new Random ();
            int indice = random.Next (confusion.Count);
            conf = confusion[indice];
            await BandejaSalida.EnviarGif (mensaje, conf);
            await BandejaSalida.EnviarMensaje (mensaje);

        }

        public static async void ErrorApi (long id)
        {
            string respuesta = "Oh no!, Se cayó Mercado Libre!";

            MensajeSalida mensaje;

            switch (id)
            {
                case 0:
                    mensaje = new MensajeSalidaConsola (respuesta, id);
                    break;

                default:
                    mensaje = new MensajeSalidaTelegram (respuesta, id);

                    break;

            }

            await BandejaSalida.EnviarMensaje (mensaje);

        }
        public static async void EnviaGif (MensajeSalida mensaje, string urlGif)
        {

            if (mensaje.Id != 0)
            {
                await BandejaSalida.EnviarGif (mensaje, urlGif);

            }

        }
        public static async Task EnviaRegalo (string regalo, long id)
        {
            MensajeSalida mensaje;

            switch (id)
            {
                case 0:
                    mensaje = new MensajeSalidaConsola (regalo, id);
                    break;

                default:
                    mensaje = new MensajeSalidaTelegram (regalo, id);
                    ImagenURL imagen = new ImagenURL ();
                    //   imagen.GuardarImagen ("https://http2.mlstatic.com/D_NQ_NP_742328-MLU33039077458_112019-V.webp");

                    //   MensajeSalidaTelegram men = (MensajeSalidaTelegram) mensaje;
                    //    men.Imagen = (@"C:\Users\FIT\repos\RegaloBot\src\Library\Respuesta\foto.webp");

                    break;

            }

            await BandejaSalida.EnviarMensaje (mensaje);

        }

        public static async Task ErrorEdad (long id)
        {
            await GenerarRespuesta ("La edad debe ser un número entre 0 y 120", id);
        }

        public static async Task ErrorPrecio (long id)
        {
            await GenerarRespuesta ("El precio debe ser un valor positivo", id);
        }
        public static async Task ErrorPrecioMax (long id)
        {
            await GenerarRespuesta ("El precio máximo debe ser un valor positivo y no puede ser menor al mínimo", id);
        }

        public static string BuscarFrase (string archivo)
        {
            return archivo;
        }

        public static string DefinirFrase (ControlEdad edad)
        {
            return "Cuantos años tiene?";
        }
        public static string DefinirFrase (ControlGenero edad)
        {
            return "El regalo es para un Hombre o una Mujer?";
        }
        public static string DefinirFrase (BaseHandler defecto)
        {
            return "Hola como andas?";
        }

        public static string DefinirFrase (ControlInteres interes)
        {
            return "Cuales son sus Intereses? que le gusta?";
        }
        public static string DefinirFrase (ControlRelacion relacion)
        {
            return "Cual es tu relación con esta persona?";
        }
        public static string DefinirFrase (GeneradorPerfil perfil)
        {
            return "Hola! Gracias por escribirnos,nos sentiamos muys solos :( \n Si nos permites vamos a hacerte algunas preguntas para Sugerirte el Mejor Regalo del Mundo Mundial.";;
        }
        public static string DefinirFrase (Busqueda busqueda)
        {
            return "Estas conforme con las Sugerencias?";
        }

        public static string DefinirFrase (ControlPrecioMin precioMin)
        {
            return "Cual es el Precio Minimo que quieres Pagar?";
        }
        public static string DefinirFrase (ControlPrecioMax precioMin)
        {
            return "Cual es el Precio Máximo que puedes pagar por este regalo?";
        }

    }
}