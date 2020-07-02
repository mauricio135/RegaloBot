namespace Library
{
    public class SelectorPlataforma
    {
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