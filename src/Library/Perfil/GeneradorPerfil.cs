using System;
namespace Library
{
    /// <summary>
    /// Clase que verifica la existencia del Perfil en el sistema, comienza la comunicación en caso de que no
    /// exista, y comienza el patrón de comportamiento Chain of Responsibility
    /// </summary>
    public class GeneradorPerfil
    {
        //Contiene un objeto que implementa la interfaz IHandler, que será el primer eslabón
        //de la Cadena de Responsabilidad
        private static IHandler handler = new ControlEdad();
        public static BibliotecaPerfiles deposito = BibliotecaPerfiles.Instance;
        /// <summary>
        /// Verifica la existencia del Perfil en el sistema, y continúa (o comienza) la interacción.
        /// </summary>
        /// <param name="mensaje">Mensaje recibido desde Plataforma, que contiene el ID de la conversación.</param>
        public static void BuscarUsuario (Mensaje mensaje)
        {
            if (!deposito.ExisteUsuario(mensaje.Id))
            {
                deposito.CrearUsuario(mensaje.Id);
                Console.WriteLine("Hola!");
            }
               
            handler.Handle(mensaje);
        }
    }
}