using Telegram.Bot.Examples.Echo;
using System.Threading;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Clase que realiza el primer procesamiento de los mensajes recibidos, por SRP,
    /// solamente genera el objeto Mensaje para comunicarlo a GeneradorPerfil. Aplicando patrón Creator,
    /// se le asignó esta responsabilidad ya que utiliza los objetos Mensaje de forma muy cercana.
    /// </summary>
    public class Plataforma
    {
        /// <summary>
        /// Formatea el contenido recibido desde el usuario y lo envía hacia GeneradorPerfil para posterior procesamiento.
        /// </summary>
        /// <param name="contenido">Contenido del mensaje enviado por el usuario</param>
        /// <param name="id">Número identificador de la conversación de la que proviene el contenido (único para cada conversación)</param>
        /// <returns></returns>
        public static Task RecibirMensaje(string contenido, long id)
        {
            GeneradorPerfil.BuscarUsuario(new Mensaje (contenido, id));
            return Task.CompletedTask;
        }
    }
}