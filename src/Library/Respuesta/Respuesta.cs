using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library
{
    public class Respuesta
    {

        public static async Task GenerarRespuesta (string contenido, long id, TipoPlataforma plataforma)
        {

            MensajeSalida mensaje = SelectorPlataforma.CrearMensajeSalida (contenido, id, plataforma);

            await BandejaSalida.EnviarMensaje (mensaje);

        }
        public static async Task PedirAclaracion (long id, TipoPlataforma plataforma)
        {
            string respuesta = "Ups, no te entendí, puedes volver a respoder?";

            MensajeSalida mensaje = SelectorPlataforma.CrearMensajeSalida (respuesta, id, plataforma);

            await BandejaSalida.EnviarReaccion (mensaje);
            await BandejaSalida.EnviarMensaje (mensaje);

        }

        public static async Task ErrorApi (long id, TipoPlataforma plataforma)
        {
            string respuesta = "Oh no!, Se cayó Mercado Libre!";

            MensajeSalida mensaje = SelectorPlataforma.CrearMensajeSalida (respuesta, id, plataforma);

            await BandejaSalida.EnviarMensaje (mensaje);

        }
        public static async Task ErrorResultado (long id, TipoPlataforma plataforma)
        {
            string respuesta = "No hay resultados por aquí...";

            MensajeSalida mensaje = SelectorPlataforma.CrearMensajeSalida (respuesta, id, plataforma);

            await BandejaSalida.EnviarMensaje (mensaje);

        }
        public static async Task Reaccion (MensajeSalida mensaje)
        {
            await BandejaSalida.EnviarReaccion (mensaje);

        }
        public static async Task EnviaRegalo (string regalo, long id, TipoPlataforma plataforma)
        {

            MensajeSalida mensaje = SelectorPlataforma.CrearMensajeSalida (regalo, id, plataforma);

            await BandejaSalida.EnviarMensaje (mensaje);

        }

        public static async Task ErrorEdad (long id, TipoPlataforma plataforma)
        {
            await GenerarRespuesta ("La edad debe ser un número entre 0 y 120", id, plataforma);
        }

        public static async Task ErrorPrecio (long id, TipoPlataforma plataforma)
        {
            await GenerarRespuesta ("El precio debe ser un valor positivo", id, plataforma);
        }
        public static async Task ErrorPrecioMax (long id, TipoPlataforma plataforma)
        {
            await GenerarRespuesta ("El precio máximo debe ser un valor positivo y no puede ser menor al mínimo", id, plataforma);
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