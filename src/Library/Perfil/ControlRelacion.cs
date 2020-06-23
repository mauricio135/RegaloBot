using System;
using System.Collections.Generic;
namespace Library
{
    /// <summary>
    /// Tercer eslabón del patrón Chain Of Responsibility. Se encarga de recibir la relación con el homenajeado
    /// del Perfil que se crea, efectuando los controles necesarios para obtener un  parámetro válido.
    /// </summary>
    public class ControlRelacion: BaseHandler
    {
        /// <summary>
        /// Como ControlRelacion contiene un objeto del tipo ControlInteres (siguiente eslabón de COR), aplicamos
        /// patrón Creator para asignarle a ControlRelacion la responsabilidad de crear objetos ControlInteres.
        /// </summary>
        public ControlRelacion()
        {
            this.Siguiente = new ControlInteres();   
        }

        /// <summary>
        /// Método que corresponde al patrón Chain of Responsibility.
        /// En caso de que el atributo Relacion correspondiente al Perfil que envía el mensaje
        /// esté fijado en el valor inicial de null, se pide una relación,
        /// y se agrega el ID a la lista de UsuariosPreguntados.
        /// 
        /// En caso de que el Perfil correspondiente tenga el valor nulo de Relación,
        /// y esté en la lista de preguntados, se procesa el valor ingresado en el 
        /// último mensaje para validarlo.
        /// De ser correcto, se modifica el campo Relacion de Perfil y se pasa al siguiente eslabón.
        /// De no ser correcto, se pide al usuario que ingrese un valor adecuado.
        /// 
        /// 
        /// Si al ingresar al método, el valor de Relacion no es el nulo, se asume que ya fue fijado por el usuario,
        /// por lo que se envía el mensaje hacia el siguiente eslabón. 
        /// </summary>
        /// <param name="m">Mensaje que se transmite por patrón COR</param>
        public override void Handle(Mensaje m)
        {
            if (BibliotecaPerfiles.GetUsuario(m.Id).Relacion == null)
            {
                if (!UsuariosPreguntados.Contains(m.Id))
                {
                    UsuariosPreguntados.Add(m.Id);
                    Preguntar(m.Id);
                }
                else
                {
                    Console.WriteLine("Proceso Relacion");
                    EditorPerfil.SetRelacion(m.Id, m.Contenido);
                    //Si está todo OK, paso al siguiente control
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
        /// pedido por un tipo de relación.
        /// </summary>

    }
}