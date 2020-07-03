using System.Collections.Generic;
namespace Library
{
    /// <summary>
    /// Interfaz de procesamiento de regalos
    /// </summary>
    public interface IProcesadorSugerencias
    {
        Regalo ProcesarRegalos(List<Regalo> regalos,int precioMin, int precioMax);
    }
}