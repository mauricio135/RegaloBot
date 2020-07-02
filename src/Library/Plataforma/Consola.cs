using System;
using System.Threading;
using System.Threading.Tasks;

namespace Library
{

    public class Consola
    {
        public static async Task<string> IniciarConsolaAsync ()
        {

             string recibido = Console.ReadLine ();
            //Task<string> recibi = ReadlineAsync ();
           // string recibido = await recibi;

            while (recibido != "quit")
            {
                await Plataforma.RecibirMensaje (recibido, 0 , TipoPlataforma.Consola);
                recibido = Console.ReadLine ();

            }
            return recibido;
        }
     /*   public static Task<string> ReadlineAsync ()
        {
            return Task.Run (() => Console.ReadLine ());

        }
*/
    }
}