namespace Library
{
/// <summary>
/// La clase BusquedaBuilder implementa ITiendaBuilder
/// </summary>
    public class BusquedaBuilder : ITiendaBuilder
    {
        private Busqueda busqueda;
        public BusquedaBuilder()
        {
            this.Reset();
        }
        public void Reset()
        {
            this.busqueda = new Busqueda();
        }
        public void SetGenerador(IGeneradorRegalo generador)
        {
            this.busqueda.GeneradorRegalo = generador;
        }

        public void SetImpresora(ImpresoraRegalo impresora)
        {
            this.busqueda.Impresora = impresora;
        }

        public void SetProcesador(IProcesadorSugerencias procesador)
        {
            this.busqueda.ProcesadorSugerencias = procesador;
        }
        public void SetTienda (ITienda tienda)
        {
            this.busqueda.Tienda = tienda;
        }
        public Busqueda GetBusqueda()
        {
            return this.busqueda;
        }
    }
}