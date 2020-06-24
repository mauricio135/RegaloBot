using System.Collections.Generic;

namespace Library
{
    public class Busqueda: BaseHandler
    {

        private ITienda tienda;
        private IGeneradorRegalo generadorRegalo;
        private IProcesadorSugerencias procesadorSugerencias;
        private ImpresoraRegalo impresora;
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
        public ImpresoraRegalo Impresora
        {
            set => impresora = value;
        }

        public Busqueda()
        {
            
        }

        public void BuscarRegalo (long idPerfil)
        {
            string regaloSugerido = generadorRegalo.SugerenciaRegalo(idPerfil);
            List<Regalo> regalos = tienda.BuscarRegalo(regaloSugerido);
            this.procesadorSugerencias.ProcesarRegalos(regalos);
            foreach (Regalo regalo in regalos)
            {
                ImpresoraRegalo.EnviarRegalo(regalo, idPerfil);
            }
        }


    }
}