using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Eslabón de la cadena que hace efectiva la búsqueda en un portal determinado
    /// </summary>
    public class Busqueda : BaseHandler
    {
        /// <summary>
        /// Listado de posibles respuestas afirmativas
        /// </summary>
        /// <value></value>
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
        /// <summary>
        /// Por patrón Creator, Busqueda crea una instancia de Despedida ya que la contiene
        /// </summary>
        public Busqueda ()
        {
            this.Siguiente = new Despedida ();

        }
        /// <summary>
        /// Entrega los resultados de la búsqueda y verifica conformidad con los mismos
        /// </summary>
        /// <param name="m">Mensaje recibido desde Plataforma</param>
        /// <returns></returns>
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
        /// <summary>
        /// Método que ejecuta la búsqueda según el Perfil dado y devuelve resultados al usuario
        /// </summary>
        /// <param name="id">Número identificador del Perfil</param>
        /// <param name="plat">Plataforma a la que se envían los resultados</param>
        /// <returns></returns>
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
        /// <summary>
        /// Ejecuta la búsqueda de regalo según interés (si no es nulo) y devuelve tres sugerencias basadas en el perfil
        /// </summary>
        /// <param name="idPerfil">Número identificador del perfil</param>
        /// <param name="plat">Plataforma a la que se debe enviar el mensaje</param>
        /// <returns></returns>
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
        /// <summary>
        /// Método que envía una pregunta al Usuario (en el caso de Busqueda, pregunta por la conformidad)
        /// </summary>
        /// <param name="id">Número identificador del perfil</param>
        /// <param name="plat">Plataforma a la que se debe enviar el mensaje</param>
        /// <returns></returns>
        public override async Task Preguntar (long id, TipoPlataforma plat)
        {
            string pregunta = Respuesta.DefinirFrase (this);
            await Respuesta.GenerarRespuesta (pregunta, id, plat);

        }
    }
}