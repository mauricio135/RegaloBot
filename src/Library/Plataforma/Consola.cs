using System; 
using System.Threading;
using System.Threading.Tasks;

namespace Library
{
    
    public class Consola
    {
        public static void IniciarConsola()
        {
            string recibido = Console.ReadLine();
            Plataforma.RecibirMensaje(recibido, 0);
            Console.WriteLine("Pasé el await");
        }
    }
}