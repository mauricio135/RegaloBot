namespace Library
{
    public interface ITiendaBuilder
    {
        void SetGenerador(IGeneradorRegalo generador);
        void SetImpresora (ImpresoraRegalo impresora);
        void SetProcesador (IProcesadorSugerencias procesador);
        void SetTienda (ITienda tienda);
    }
}