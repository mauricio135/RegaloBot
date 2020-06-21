namespace Library
{
    public class Busqueda: BaseHandler
    {

        private ITienda tienda;
        private IGeneradorRegalo generadorRegalo;
        private IProcesadorSugerencias procesadorSugerencias;
        public ITienda Tienda
        {
            set => tienda = value;
        }
        public IGeneradorRegalo GeneradorRegalo
        {
            set => generadorRegalo = value;
        }
        public IProcesadorSugerencias ProcesadorSugerencias
        {
            set => procesadorSugerencias = value;
        }

        public Busqueda()
        {
            
        }

        public void BuscarRegalo (long idPerfil)
        {

        }


    }
}