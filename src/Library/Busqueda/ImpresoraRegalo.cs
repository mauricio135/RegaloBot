using System;
namespace Library
{
    public class ImpresoraRegalo
    {
        public static void EnviarRegalo (Regalo regalo, long idPerfil)
        {
            Respuesta.EnviaRegalo(regalo.ToString(), idPerfil);
           // Console.WriteLine(regalo.ToString());
        }
    }
}