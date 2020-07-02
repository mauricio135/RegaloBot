using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library
{
    public class Busqueda : BaseHandler
    {
        private List<string> afirmativo = new List<string>
        {
            "si",
            "correcto",
            "vapai",
            "OK",
            "sabelo",
            "me encanta",
            "buenisimo",
            "obvio",
            "dale"
        };

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

        public Busqueda ()
        {
            this.Siguiente = new Despedida ();

        }
        public override async void Handle (Mensaje m)
        {
            Perfil perfil = BibliotecaPerfiles.GetUsuario (m.Id);
            if (!perfil.RegistroPreguntas.Busqueda)
            {
                await EjecutarBusqueda (m.Id, m.Plataforma);
                perfil.RegistroPreguntas.Busqueda = true;

            }
            else
            {
                if (afirmativo.Contains (m.Contenido.ToLower ()))
                {
                    Siguiente.Handle (m);

                }
                else
                {
                    await EjecutarBusqueda (m.Id, m.Plataforma);
                }

            }
        }
        private async Task EjecutarBusqueda (long id, TipoPlataforma plat)
        {
            try
            {
                await this.BuscarRegalo (id, plat);
                await this.Preguntar (id, plat);
            }
            catch (NullReferenceException)
            {
                await Respuesta.ErrorApi (id, plat);

            }

        }

        public async Task BuscarRegalo (long idPerfil, TipoPlataforma plat)
        {
            Perfil perfil = BibliotecaPerfiles.GetUsuario (idPerfil);

            int precioMin = perfil.PrecioMin;
            int precioMax = perfil.PrecioMax;
            string interes = perfil.Interes;

            if (interes != null)
            {
                List<Regalo> regalos = tienda.BuscarRegalo (interes);
                try
                {
                    Regalo resultado = this.procesadorSugerencias.ProcesarRegalos (regalos, precioMin, precioMax);

                    await ImpresoraRegalo.EnviarRegalo (resultado, idPerfil, plat);
                }
                catch
                {
                    await Respuesta.ErrorResultado (idPerfil, plat);

                }

            }

            for (int i = 0; i < 3; i++)
            {
                string regaloSugerido = generadorRegalo.SugerenciaRegalo (idPerfil);
                List<Regalo> regalos = tienda.BuscarRegalo (regaloSugerido);
                try
                {
                    Regalo resultado = this.procesadorSugerencias.ProcesarRegalos (regalos, precioMin, precioMax);

                    await ImpresoraRegalo.EnviarRegalo (resultado, idPerfil, plat);
                }
                catch
                {
                    await Respuesta.ErrorResultado (idPerfil, plat);

                }

            }

        }

        public override async Task Preguntar (long id, TipoPlataforma plat)
        {
            string pregunta = Respuesta.DefinirFrase (this);
            await Respuesta.GenerarRespuesta (pregunta, id, plat);

        }
    }
}