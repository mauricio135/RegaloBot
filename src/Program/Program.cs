using System;
using System.Threading.Tasks;
using Library;

namespace Program
{
    class Program
    {
        static void Main (string[] args)
        {
            Bot.IniciarBot ();

            foreach (Perfil usuario in BibliotecaPerfiles.lista)
            {
                Console.WriteLine ($"{usuario}");
            }

        }
    }
}