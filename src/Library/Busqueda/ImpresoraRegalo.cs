using System;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Por SRP, la única razón de cambio de esta clase es que se decida cambiar la forma de presentación de sugerencia de Regalo al Usuario
    /// </summary>
    public class ImpresoraRegalo
    {
        public static async Task EnviarRegalo (Regalo regalo, long idPerfil ,TipoPlataforma plat)
        {
           await Respuesta.EnviaRegalo(regalo.ToString(), idPerfil , plat);
        }
    }
}