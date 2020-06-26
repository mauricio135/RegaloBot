using System;
using System.Collections.Generic;
namespace Library
{
    /// <summary>
    /// Sexto eslabón del patrón Chain Of Responsibility. Se encarga de recibir el valor de la edad
    /// del Perfil que se crea, efectuando los controles necesarios para obtener un  parámetro válido.
    /// </summary>
    public class ControlPrecioMax: BaseHandler
    {
        
        public ControlPrecioMax()
        {
            
        }
        
        /// <summary>
        /// Método que corresponde al patrón Chain of Responsibility.
        /// En caso de que el precio maximo correspondiente al perfil que envía el mensaje
        /// esté fijado en el valor inicial de -1, se pide un valor de Precio Maximo,
        /// y se agrega el ID a la lista de UsuariosPreguntados.
        /// 
        /// En caso de que el Perfil correspondiente tenga el valor inicial de Precio Maximo,
        /// y esté en la lista de preguntados, se procesa el valor ingresado en el 
        /// último mensaje para validarlo.
        /// De ser correcto, se modifica el campo Precio Maximo de Perfil
        /// De no ser correcto, se pide al usuario que ingrese un valor adecuado.
        /// 
        /// 
        /// Si al ingresar al método, el valor de Precio maximo no es el inicial, se asume que ya fue fijado por el usuario,
        /// por lo que se envía el mensaje hacia el siguiente eslabón. 
        /// </summary>
        /// <param name="m">Mensaje que se transmite por patrón COR</param>
        public override void Handle(Mensaje m)
        {
            if (BibliotecaPerfiles.GetUsuario(m.Id).PrecioMax == -1)
            {
                if (!UsuariosPreguntados.Contains(m.Id))
                {
                    UsuariosPreguntados.Add(m.Id);
                    Preguntar(m.Id);
                }
                else
                {
                    Console.WriteLine("Proceso Precio Maximo");
                    int precioMax = Int32.Parse(m.Contenido);
                    EditorPerfil.SetPrecioMax(m.Id, precioMax);
                    //Si está todo OK, paso al siguiente eslabón
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
        /// pedido por un valor de Precio Maximo.
        /// </summary>


    }
}