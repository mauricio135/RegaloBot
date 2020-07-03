using System;
using System.Threading;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Clase que provee la comunicación con el bot mediante consola
    /// </summary>
    public class Consola
    {
        public static async Task<string> IniciarConsolaAsync ()
        {

            string recibido = Console.ReadLine ();

            while (recibido != "quit")
            {
                await Plataforma.RecibirMensaje (recibido, 0 , TipoPlataforma.Consola);
                recibido = Console.ReadLine ();

            }
            return recibido;
        }
    }
}