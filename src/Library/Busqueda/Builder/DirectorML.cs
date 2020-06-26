namespace Library
{
    public class DirectorML
    {
        private ITiendaBuilder tiendaBuilder;
        public ITiendaBuilder TiendaBuilder
        {
            set => tiendaBuilder = value;
        }
        public void BusquedaML()
        {
            this.tiendaBuilder.SetTienda(new MercadoLibre());
            this.tiendaBuilder.SetProcesador(new ProcesadorSimple());
            this.tiendaBuilder.SetImpresora (new ImpresoraRegalo ());
            this.tiendaBuilder.SetGenerador (new GeneradorPipes());
        }
    }
}