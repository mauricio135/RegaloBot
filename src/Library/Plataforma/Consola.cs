using System; 
using System.Threading;
using System.Threading.Tasks;

namespace Library
{
    
    public class Consola
    {
        public static async Task IniciarConsola()
        {
            string recibido = Console.ReadLine();
           await  Plataforma.RecibirMensaje(recibido, 0);
            Console.WriteLine("Captura de comandline");
        }
    }
}