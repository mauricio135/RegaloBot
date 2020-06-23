namespace Library
{
    public class Respuesta
    {
        private static ILectorArchivos lectorArchivos;
        public static void GenerarRespuesta (IHandler tipo, long id)
        {
            string archivo = DefinirFrase(tipo);
            string contenido = BuscarFrase(archivo);
            MensajeSalida mensaje= new MensajeSalidaTelegram(contenido, id);
            BandejaSalida.EnviarMensaje(mensaje);
        }


        public static string BuscarFrase (string archivo)
        {
            return archivo;
        }
        public static string DefinirFrase(IHandler defecto)
        {
            return "default";
        }
        public static string DefinirFrase(ControlEdad edad)
        {
            return "edad";
        }

        //Completar con los tipos
    }
}