using System;

namespace Library
{
    public class Respuesta
    {

        private static ILectorArchivos lectorArchivos;
        public static void GenerarRespuesta (string contenido, long id)
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

            BandejaSalida.EnviarMensaje (mensaje);

        }

        public static void EnviaRegalo (string regalo, long id)
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
                    imagen.GuardarImagen ("https://http2.mlstatic.com/D_NQ_NP_742328-MLU33039077458_112019-V.webp");

                    MensajeSalidaTelegram men = (MensajeSalidaTelegram) mensaje;
                    men.Imagen = (@"C:\Users\FIT\repos\RegaloBot\src\Library\Respuesta\foto.webp");

                    break;

            }

            BandejaSalida.EnviarMensaje (mensaje);

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
            return "Cuales son sus Intereses?";
        }
        public static string DefinirFrase (ControlRelacion relacion)
        {
            return "Cual es tu relacion con esta persona?";
        }
        public static string DefinirFrase (GeneradorPerfil perfil)
        {
            return "Hola! Gracias por escribirnos,nos sentiamos muys solos :( \n Si nos permites vamos a hacerte algunas preguntas para Sugerirte el Mejor Regalo del Mundo Mundial";
;
        }
        public static string DefinirFrase (Busqueda busqueda)
        {
            return "Esta conforme con las Sugerencias?";
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