using System;

namespace Library
{
    public class Respuesta
    {
        
        private static ILectorArchivos lectorArchivos;
        public static void GenerarRespuesta (string contenido, long id)
        {
           // string archivo = DefinirFrase(tipo.GetType());
            // contenido = BuscarFrase (archivo);
           MensajeSalida mensaje = new MensajeSalida(contenido,id);
            
            BandejaSalida.EnviarMensaje (mensaje);
        }
       

        public static string BuscarFrase (string archivo)
        {
            return archivo;
        }
       
        public static string DefinirFrase (ControlEdad edad)
        {
            return "Cuanto años Tienes?";
        }
        public static string DefinirFrase (ControlGenero edad)
        {
            return "Eres un Hombre o una Mujer?";
        }
         public static string DefinirFrase (BaseHandler defecto)
        {
            return "Hola como andas?";
        }

          public static string DefinirFrase (ControlInteres interes)
        {
            return "Cuales son tus Intereses?";
        }
         public static string DefinirFrase (ControlRelacion relacion)
        {
            return "Cual es tu relacion con la persona?";
        }
            public static string DefinirFrase (GeneradorPerfil perfil)
        {
            return "Bienvenido! se ha creado un Perfil nuevo!";
        }


        //Completar con los tipos
    }
}