using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

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
            string respuesta="Ups, no te entendí, puedes volver a responder?";
            try
            {
            respuesta = leerarchivo.Leer("NoEntendi");
            }
            catch(DirectoryNotFoundException)
            {
                Console.WriteLine("No se encontro archivo");
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("No se encontro archivo");
            }
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

        public static async Task ErrorPrecioMin (long id, TipoPlataforma plataforma)
        {
            await GenerarRespuesta ("El precio debe ser un valor positivo", id, plataforma);
        }
        public static async Task ErrorPrecioMax (long id, TipoPlataforma plataforma)
        {
            await GenerarRespuesta ("El precio máximo debe ser un valor positivo y no puede ser menor al mínimo", id, plataforma);
        }

        public static string DefinirFrase (ControlEdad edad)
        {
            
            string respuesta = "Cuantos años tiene";
            try
            {
            respuesta = leerarchivo.Leer("Edad");
            }
            catch(DirectoryNotFoundException)
            {
                Console.WriteLine("No se encontro archivo");
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("No se encontro archivo");
            }
            return respuesta;
        }
        public static string DefinirFrase (ControlGenero genero)
        {

            string respuesta = "El regalo es para un Hombre o una Mujer?";
            try
            {
            respuesta = leerarchivo.Leer("Genero");
            }
            catch(DirectoryNotFoundException)
            {
                Console.WriteLine("No se encontro archivo");
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("No se encontro archivo");
            }
            return respuesta;
            
        }
        public static string DefinirFrase (BaseHandler defecto)
        {
            return "Hola como andas?";
        }

        public static string DefinirFrase (ControlInteres interes)
        {
            
            string respuesta = "Cuales son sus Intereses? que le gusta??";
            try
            {
            respuesta = leerarchivo.Leer("Intereses");
            }
            catch(DirectoryNotFoundException)
            {
                Console.WriteLine("No se encontro archivo");
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("No se encontro archivo");
            }
            return respuesta;
        }
        public static string DefinirFrase (Despedida despedida)

        {
            string respuesta = "nos vemos ,Chau!";
            try
            {
            respuesta = leerarchivo.Leer("Despedida");
            }
            catch(DirectoryNotFoundException)
            {
                Console.WriteLine("No se encontro archivo");
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("No se encontro archivo");
            }
            return respuesta;
            
        }
        public static string DefinirFrase (ControlRelacion relacion)
        {
            
            string respuesta = "Cual es tu relación con esta persona?";
            try
            {
            respuesta = leerarchivo.Leer("Relacion");
            }
            catch(DirectoryNotFoundException)
            {
                Console.WriteLine("No se encontro archivo");
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("No se encontro archivo");
            }
            return respuesta;
            
        }
        public static string DefinirFrase (GeneradorPerfil perfil)
        {
            string respuesta = "Hola! Gracias por escribirnos,nos sentiamos muy solos :( \n Si nos permites vamos a hacerte algunas preguntas para Sugerirte el Mejor Regalo del Mundo Mundial.";
            try
            {
            respuesta = leerarchivo.Leer("Saludo");
            }
            catch(DirectoryNotFoundException)
            {
                Console.WriteLine("No se encontro archivo");
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("No se encontro archivo");
            }
            return respuesta;        
        }
        public static string DefinirFrase (string saludo)
        {
            string respuesta = "Hola! Gracias por escribirnos,nos sentiamos muy solos :( \n Si nos permites vamos a hacerte algunas preguntas para Sugerirte el Mejor Regalo del Mundo Mundial.";
            try
            {
            respuesta = leerarchivo.Leer("Saludo");
            }
            catch(DirectoryNotFoundException)
            {
                Console.WriteLine("No se encontro archivo");
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("No se encontro archivo");
            }
            return respuesta;        
        }

        public static string DefinirFrase (Busqueda busqueda)
        {
            string respuesta = "Estas conforme con las Sugerencias?";
            try
            {
            respuesta = leerarchivo.Leer("Busqueda");
            }
            catch(DirectoryNotFoundException)
            {
                Console.WriteLine("No se encontro archivo");
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("No se encontro archivo");
            }
            return respuesta;
        }

        public static string DefinirFrase (ControlPrecioMin precioMin)
        {
            string respuesta = "Cual es el Precio Minimo que quieres Pagar?";
            try
            {
            respuesta = leerarchivo.Leer("PrecioMin");
            }
            catch(DirectoryNotFoundException)
            {
                Console.WriteLine("No se encontro archivo");
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("No se encontro archivo");
            }
            return respuesta;
        }
        public static string DefinirFrase (ControlPrecioMax precioMax)
        {
            string respuesta ="Cual es el Precio Máximo que puedes pagar por este regalo?";
            try
            {
            respuesta = leerarchivo.Leer("PrecioMax");
            }
            catch(DirectoryNotFoundException)
            {
                Console.WriteLine("No se encontro archivo");
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("No se encontro archivo");
            }
            return respuesta;
            
        }

    }
}