using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public override async void Handle(Mensaje m)
        {
            try
            {                
            this.BuscarRegalo(m.Id);            
            await this.Preguntar(m.Id);
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

        public override async Task Preguntar (long id)
        {
            string pregunta = Respuesta.DefinirFrase (this);
            await Respuesta.GenerarRespuesta (pregunta, id);

        }
    }
}