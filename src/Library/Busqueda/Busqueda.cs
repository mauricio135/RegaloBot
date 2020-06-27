using System;
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
        public override void Handle(Mensaje m)
        {
            try
            {                
            this.BuscarRegalo(m.Id);            
            this.Preguntar(m.Id);
            }   
            catch (NullReferenceException)
            {
                Respuesta.ErrorApi(m.Id);

            }         
        }
    

        public void BuscarRegalo (long idPerfil)
        {
            for (int i = 0; i < 3; i++)
            {
                string regaloSugerido = generadorRegalo.SugerenciaRegalo(idPerfil);
                List<Regalo> regalos = tienda.BuscarRegalo(regaloSugerido);
                List<Regalo> resultados = this.procesadorSugerencias.ProcesarRegalos(regalos);
                foreach (Regalo resultado in resultados)
                {
                    ImpresoraRegalo.EnviarRegalo(resultado, idPerfil);
                } 
            }
            
        }

        public override void Preguntar(long id)
        {
            string pregunta = Respuesta.DefinirFrase(this);
            Respuesta.GenerarRespuesta(pregunta,id);
        }
    }
}