using System;
using System.Collections.Generic;
namespace Library
{
    /// <summary>
    /// Cuarto eslabón del patrón Chain Of Responsibility. Se encarga de recibir un interés
    /// del Perfil que se crea, efectuando los controles necesarios para obtener un  parámetro válido.
    /// </summary>
    public class ControlInteres: BaseHandler
    {
        public ControlInteres()
        {
            var directorMl = new DirectorML();
            var builder = new BusquedaBuilder();
            directorMl.TiendaBuilder = builder;
            directorMl.BusquedaML();   
            this.Siguiente = builder.GetBusqueda();            
        }

        /// <summary>
        /// Método que corresponde al patrón Chain of Responsibility.
        /// En caso de que el atributo Interes correspondiente al Perfil que envía el mensaje
        /// esté fijado en el valor inicial de null, se pide un interés,
        /// y se agrega el ID a la lista de UsuariosPreguntados.
        /// 
        /// En caso de que el Perfil correspondiente tenga el valor nulo de Interes,
        /// y esté en la lista de preguntados, se procesa el valor ingresado en el 
        /// último mensaje para validarlo.
        /// De ser correcto, se modifica el campo Interes de Perfil y se pasa al siguiente eslabón.
        /// De no ser correcto, se pide al usuario que ingrese un valor adecuado.
        /// 
        /// 
        /// Si al ingresar al método, el valor de Interes no es el nulo, se asume que ya fue fijado por el usuario,
        /// por lo que se envía el mensaje hacia el siguiente eslabón. 
        /// </summary>
        /// <param name="m">Mensaje que se transmite por patrón COR</param>

        public override void Handle(Mensaje m)
        {
            if (BibliotecaPerfiles.GetUsuario(m.Id).Interes == null)
            {
                if (!UsuariosPreguntados.Contains(m.Id))
                {
                    Console.WriteLine("Pregunto Interes");
                    UsuariosPreguntados.Add(m.Id);
                }
                else
                {
                    Console.WriteLine("Proceso Interes");
                    EditorPerfil.SetInteres(m.Id, m.Contenido);
                    Siguiente.Handle(m);
                }
            }
            else
            {
                Siguiente.Handle(m);
            }
        }
        /// <summary>
        /// Método que se encarga de trasladar a la clase encargada de enviar mensajes al usuario el
        /// pedido por un interés.
        /// </summary>
        public override void Preguntar()
        {
            Console.WriteLine("Pregunto Interes");
        }

    }
}