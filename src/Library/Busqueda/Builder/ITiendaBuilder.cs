namespace Library
{
    /// <summary>
    /// Interfaz necesaria para aplicar el patrón de diseño Builder sobre la clase Busqueda
    /// </summary>
    public interface ITiendaBuilder
    {
        void SetGenerador(IGeneradorRegalo generador);
        void SetImpresora (ImpresoraRegalo impresora);
        void SetProcesador (IProcesadorSugerencias procesador);
        void SetTienda (ITienda tienda);
    }
}