using System;
using System.Threading.Tasks;
using Library;

namespace Program
{
    class Program
    {
        static async Task Main (string[] args)
        {
            Bot.IniciarBot ();
            string entrada = "";
            while (entrada != "quit")
            {
                await Consola.IniciarConsola ();

                foreach (Perfil usuario in BibliotecaPerfiles.lista)
                {
                    Console.WriteLine ($"{usuario}");
                }
            }
        }
    }
}