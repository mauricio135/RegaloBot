using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

public class leerarchivo
{
  
    public static string Leer(string ruta)
    {   
        string rutaRelativa = @"..\Archivo\";
        string rutaFinal = rutaRelativa+ruta+".txt";

        List<string> saludos=new List<string>();
        using (StreamReader leer = new StreamReader(rutaFinal))
        {
            string linea;

            while((linea=leer.ReadLine())!=null)
            {
                saludos.Add(linea);         
            }
            leer.Close();
        }
        var random = new Random();
        int indice = random.Next(saludos.Count);
        return saludos[indice];

    }
    
}