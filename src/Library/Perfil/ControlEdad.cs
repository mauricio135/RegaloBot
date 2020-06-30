using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Primer eslabón del patrón Chain Of Responsibility. Se encarga de recibir el valor de la edad
    /// del Perfil que se crea, efectuando los controles necesarios para obtener un  parámetro válido.
    /// </summary>
    public class ControlEdad : BaseHandler
    {
        /// <summary>
        /// Como ControlEdad contiene un objeto del tipo ControlGenero (siguiente eslabón de COR), aplicamos
        /// patrón Creator para asignarle a ControlEdad la responsabilidad de crear objetos ControlGenero.
        /// </summary>
        public ControlEdad ()
        {
            this.Siguiente = new ControlGenero ();
        }

        /// <summary>
        /// Método que corresponde al patrón Chain of Responsibility.
        /// En caso de que la Edad correspondiente al perfil que envía el mensaje
        /// esté fijada en el valor inicial de -1, se pide un valor de Edad,
        /// y se agrega el ID a la lista de UsuariosPreguntados.
        /// 
        /// En caso de que el Perfil correspondiente tenga el valor inicial de Edad,
        /// y esté en la lista de preguntados, se procesa el valor ingresado en el 
        /// último mensaje para validarlo.
        /// De ser correcto, se modifica el campo Edad de Perfil y se pasa al siguiente eslabón.
        /// De no ser correcto, se pide al usuario que ingrese un valor adecuado.
        /// 
        /// 
        /// Si al ingresar al método, el valor de Edad no es el inicial, se asume que ya fue fijado por el usuario,
        /// por lo que se envía el mensaje hacia el siguiente eslabón. 
        /// </summary>
        /// <param name="m">Mensaje que se transmite por patrón COR</param>
        public override async void Handle (Mensaje m)
        {
            if (BibliotecaPerfiles.GetUsuario (m.Id).Edad == -1)
            {
                if (!UsuariosPreguntados.Contains (m.Id))
                {
                    UsuariosPreguntados.Add (m.Id);
                    await Preguntar (m.Id);
                }
                else
                {
                    /// <summary>
                    /// Intento parsear el contenido del mensaje a un numero entero, si lo consigue pasa al siguiente eslabón.
                    /// </summary>
                    
                    try 
                    {
                        int edad = Int32.Parse(m.Contenido);
                        EditorPerfil.SetEdad (m.Id, edad);
                        Siguiente.Handle (m);

                    }
                    /// <summary>
                    /// Si el parseo falla, por ejemplo si recibo una letra, captura la excepción y envia un mensaje al usuario
                    /// pidiendo que ingrese un valor valido de edad
                    /// </summary>
                    catch(FormatException)
                    {

                       await  Respuesta.PedirAclaracion (m.Id);
                       await  Preguntar(m.Id);


                    }
                    

                }
            }
            else
            {
                Siguiente.Handle (m);
            }
        }
        /// <summary>
        /// Método que se encarga de trasladar a la clase encargada de enviar mensajes al usuario el
        /// pedido por un valor de Edad.
        /// </summary>
        public override async Task Preguntar (long id)
        {
            string pregunta = Respuesta.DefinirFrase (this);
           await Respuesta.GenerarRespuesta (pregunta, id);

        }

    }
}