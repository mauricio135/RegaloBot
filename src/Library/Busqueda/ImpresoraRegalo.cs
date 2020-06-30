using System;
using System.Threading.Tasks;

namespace Library
{
    public class ImpresoraRegalo
    {
        public static async Task EnviarRegalo (Regalo regalo, long idPerfil)
        {
           await Respuesta.EnviaRegalo(regalo.ToString(), idPerfil);
            Console.WriteLine(regalo.ToString());
        }
    }
}