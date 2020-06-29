using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Library
{
    public class ImagenURL
    {
        public void GuardarImagen (string imageUrl)
        {
            if (imageUrl == null) 
            throw new ArgumentNullException("La Url de la imagen no puede ser vacia");

            using (WebClient client = new WebClient ())
            {
               // client.DownloadFile (new Uri (url), @"c:\temp\image35.png");
                // OR 
                client.DownloadFileAsync (new Uri (imageUrl), @"c:\Users\FIT\repos\RegaloBot\src\Library\Respuesta\foto.webp");
            }
            // Task.CompletedTask;
          

        }
    }
}