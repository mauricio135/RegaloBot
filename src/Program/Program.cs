using System;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Bot.IniciarBot();
            string entrada = Console.ReadLine();
            while (entrada != "quit")
            {
                entrada = Console.ReadLine();
            }

            foreach (Perfil usuario in BibliotecaPerfiles.lista)
            {
                Console.WriteLine($"{usuario}");
            }
        }
    }
}
