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
            await this.BuscarRegalo(m.Id);            
            await this.Preguntar(m.Id);
            }   
            catch (NullReferenceException)
            {
                Respuesta.ErrorApi(m.Id);

            }         
        }
    

        public async Task BuscarRegalo (long idPerfil)
        {
            int precioMin = BibliotecaPerfiles.GetUsuario(idPerfil).PrecioMin;
            int precioMax = BibliotecaPerfiles.GetUsuario(idPerfil).PrecioMax;
            for (int i = 0; i < 3; i++)
            {
                string regaloSugerido = generadorRegalo.SugerenciaRegalo(idPerfil);
                List<Regalo> regalos = tienda.BuscarRegalo(regaloSugerido);
                List<Regalo> resultados = this.procesadorSugerencias.ProcesarRegalos(regalos, precioMin, precioMax);
                foreach (Regalo resultado in resultados)
                {
                    await ImpresoraRegalo.EnviarRegalo(resultado, idPerfil);
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