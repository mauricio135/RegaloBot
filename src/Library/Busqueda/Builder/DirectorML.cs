namespace Library
{
    /// <summary>
    /// Clase responsable de ordenar los pasos de la construcción de la instancia de Busqueda que vamos a utilizar, seleccionando los objetos específicos de la búsqueda en MercadoLibre que vamos a realizar
    /// </summary>
    public class DirectorML
    {
        /// <summary>
        /// Atributo encapsulado tiendaBuilder, quien construye la instancia de Busqueda
        /// </summary>
        private ITiendaBuilder tiendaBuilder;
        /// <summary>
        /// Property TiendaBuilder, para determinar un Builder adecuado al objeto
        /// </summary>
        /// <value></value>
        public ITiendaBuilder TiendaBuilder
        {
            set => tiendaBuilder = value;
        }
        /// <summary>
        /// El método BusquedaML construye un objeto Busqueda con MercadoLibre como ITienda, un ProcesadorSimple, una ImpresoraRegalo y un GeneradorPipes como IGeneradorRegalos.
        /// </summary>
        public void BusquedaML()
        {
            this.tiendaBuilder.SetTienda(new MercadoLibre());
            this.tiendaBuilder.SetProcesador(new ProcesadorSimple());
            this.tiendaBuilder.SetImpresora (new ImpresoraRegalo ());
            this.tiendaBuilder.SetGenerador (new GeneradorPipes());
        }
    }
}