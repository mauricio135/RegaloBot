namespace Library
{
/// <summary>
/// Atendiendo al patrón Builder, la clase BusquedaBuilder es la implementación concreta de ITiendaBuilder que vamos a utilizar
/// </summary>
    public class BusquedaBuilder : ITiendaBuilder
    {
        /// <summary>
        /// Objeto del tipo Busqueda que vamos a construir
        /// </summary>
        private Busqueda busqueda;
        /// <summary>
        /// El constructor de BusquedaBuilder requiere reiniciar la instancia de BusquedaBuilder
        /// </summary>
        public BusquedaBuilder()
        {
            this.Reset();
        }
        /// <summary>
        /// Reinicio de la construción de Busqueda
        /// </summary>
        public void Reset()
        {
            this.busqueda = new Busqueda();
        }
        /// <summary>
        /// Paso requerido para construir Busqueda (designar un objeto que genere las recomendaciones de regalo)
        /// </summary>
        /// <param name="generador">Objeto que implemente la interfaz IGeneradorRegalo</param>
        public void SetGenerador(IGeneradorRegalo generador)
        {
            this.busqueda.GeneradorRegalo = generador;
        }

        /// <summary>
        /// Paso requerido para construir Busqueda (designar un objeto que prepare para el envío a las recomendaciones de regalo)
        /// </summary>
        /// <param name="impresora">Objeto de la clase ImpresoraRegalo</param>
        public void SetImpresora(ImpresoraRegalo impresora)
        {
            this.busqueda.Impresora = impresora;
        }

        /// <summary>
        /// Paso requerido para construir Busqueda (designar un objeto que procese bajo distintos métodos las recomendaciones de regalo)
        /// </summary>
        /// <param name="impresora">Objeto que implemente la interfaz IPRocesadorSugerencias</param>

        public void SetProcesador(IProcesadorSugerencias procesador)
        {
            this.busqueda.ProcesadorSugerencias = procesador;
        }
        /// <summary>
        /// Paso requerido para construir Busqueda (designar un objeto del tipo ITienda que brinde acceso al portal en el que se busca)
        /// </summary>
        /// <param name="impresora">Objeto que implemente a la interfaz ITienda</param>

        public void SetTienda (ITienda tienda)
        {
            this.busqueda.Tienda = tienda;
        }
        /// <summary>
        /// Método que devuelve el objeto Busqueda contenida en BusquedaBuilder
        /// </summary>
        /// <returns>El objeto de tipo Busqueda construido</returns>
        public Busqueda GetBusqueda()
        {
            return this.busqueda;
        }
    }
}