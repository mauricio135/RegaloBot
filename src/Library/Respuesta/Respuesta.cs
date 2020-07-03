using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace Library
{
    /// <summary>
    /// Clase que maneja las respuestas enviadas hacia el usuario
    /// </summary>
    public class Respuesta
    {
        /// <summary>
        /// Método que genera la respuesta hacia el usuario. Se utiliza Delegación para la creación de la instancia
        /// de MensajeSalida, y para el envío mediante la plataforma
        /// </summary>
        /// <param name="contenido">Contenido del mensaje</param>
        /// <param name="id">Identificador de la conversación</param>
        /// <param name="plataforma">Plataforma por la que se debe enviar el mensaje</param>
        /// <returns></returns>

        public static async Task GenerarRespuesta (string contenido, long id, TipoPlataforma plataforma)
        {

            MensajeSalida mensaje = SelectorPlataforma.CrearMensajeSalida (contenido, id, plataforma);

            await BandejaSalida.EnviarMensaje (mensaje);

        }
        /// <summary>
        /// Método que pide una aclacración al usuario. Delega la responsabilidad de leer el archivo
        /// </summary>
        /// <param name="id">Identificador de la conversación</param>
        /// <param name="plataforma">Plataforma por la cual se debe enviar el mensaje</param>
        /// <returns></returns>
        public static async Task PedirAclaracion (long id, TipoPlataforma plataforma)
        {
            string respuesta="Ups, no te entendí, ¿puedes volver a responder?";
            try
            {
            respuesta = LeerArchivo.Leer("NoEntendi");
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
        /// <summary>
        /// Por polimorfismo, no se conoce de antemano qué implementación del método se va a ejecutar,
        /// ya que las clases que heredan de MensajeSalida tienen distintas implementaciones de EnviarReaccion
        /// </summary>
        /// <param name="mensaje">Mensaje a enviar</param>
        /// <returns></returns>
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

        //A continuación se encuentran los métodos que cada Handler utiliza para comunicarse con el usuario. 
        //Se utiliza sobrecarga, ya que cada uno tiene sus propios mensajes.

        #region 

        public static string DefinirFrase (ControlEdad edad)
        {
            
            string respuesta = "Cuantos años tiene";
            try
            {
            respuesta = LeerArchivo.Leer("Edad");
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
            respuesta = LeerArchivo.Leer("Genero");
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
            respuesta = LeerArchivo.Leer("Intereses");
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
            respuesta = LeerArchivo.Leer("Despedida");
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
            respuesta = LeerArchivo.Leer("Relacion");
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
            respuesta = LeerArchivo.Leer("Saludo");
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
            respuesta = LeerArchivo.Leer("Saludo");
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
            respuesta = LeerArchivo.Leer("Busqueda");
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
            respuesta = LeerArchivo.Leer("PrecioMin");
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
            respuesta = LeerArchivo.Leer("PrecioMax");
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
        #endregion

    }
}