using System;

namespace Library
{
    public class Respuesta
    {

        private static ILectorArchivos lectorArchivos;
        public static void GenerarRespuesta (string contenido, long id)
        {
           //string cont = BuscarFrase (archivo);
            MensajeSalida mensaje ;

            switch (id)
            {
                case 0:
                         mensaje = new MensajeSalidaConsola (contenido, id);
                break;

                default :
                         mensaje = new MensajeSalidaTelegram (contenido, id);

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
            return "Cuantos **años** tiene?";
        }
        public static string DefinirFrase (ControlGenero edad)
        {
            return "Eres un **Hombre** o una **Mujer**?";
        }
        public static string DefinirFrase (BaseHandler defecto)
        {
            return "Hola como andas?";
        }

        public static string DefinirFrase (ControlInteres interes)
        {
            return "Cuales son tus **Intereses**?";
        }
        public static string DefinirFrase (ControlRelacion relacion)
        {
            return "Cual es tu **relacion** con esta persona?";
        }
        public static string DefinirFrase (GeneradorPerfil perfil)
        {
            return "Bienvenido! se ha creado un nuevo Perfil!";
        }

    }
}