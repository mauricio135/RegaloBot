namespace Library
{
    /// <summary>
    /// Clase que crea instancias de MensajeSalida dependiendo de su TipoPlataforma. Por OCP podemos extender
    /// a más plataformas sin necesidad de modificar lo ya hecho (se debería agregar otro TipoPlataforma)
    /// </summary>
    public class SelectorPlataforma
    {
        /// <summary>
        /// Crea MensajeSalida. 
        /// </summary>
        /// <param name="contenido">Contenido del mensaje</param>
        /// <param name="id">Identificador de la conversación</param>
        /// <param name="plataforma">Tipo de plataforma de la conversación</param>
        /// <returns></returns>
        public static MensajeSalida CrearMensajeSalida (string contenido, long id, TipoPlataforma plataforma)
        {
            MensajeSalida mensajeSalida;
            switch (plataforma)
            {

                case TipoPlataforma.Consola:
                    mensajeSalida = new MensajeSalidaConsola (contenido, id);
                    break;

                case TipoPlataforma.Telegram:
                    mensajeSalida = new MensajeSalidaTelegram (contenido, id);
                    break;

                default:
                    mensajeSalida = new MensajeSalidaConsola (contenido, id);
                    break;

            }
            return mensajeSalida;
        }

    }
}