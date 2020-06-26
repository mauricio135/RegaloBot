using System;
using System.Collections.Generic;
namespace Library
{
    /// <summary>
    /// Segundo eslabón del patrón Chain Of Responsibility. Se encarga de recibir el género
    /// del Perfil que se crea, efectuando los controles necesarios para obtener un  parámetro válido.
    /// </summary>
    public class ControlGenero : BaseHandler
    {

        private static List<string> masculino = new List<string> ()
        {
            "hombre",
            "masculino",
            "m",
            "masc",
            "varon",
            "varón",
            "niño",
            "nene",
            "ombre",
            "homvre",
            "honvre",
            "macho"
        };

        private static List<string> femenino = new List<string> ()
        {
            "mujer",
            "femenino",
            "f",
            "fem",
            "nena",
            "gurisa",
            "muger",
            "femenina"
        };
        /// <summary>
        /// Como ControlGenero contiene un objeto del tipo ControlRelacion (siguiente eslabón de COR), aplicamos
        /// patrón Creator para asignarle a ControlGenero la responsabilidad de crear objetos ControlRelacion.
        /// </summary>
        public ControlGenero ()
        {
            this.Siguiente = new ControlRelacion ();
        }

        /// <summary>
        /// Método que corresponde al patrón Chain of Responsibility.
        /// En caso de que el género correspondiente al Perfil que envía el mensaje
        /// esté fijado en el valor inicial de null, se pide un género,
        /// y se agrega el ID a la lista de UsuariosPreguntados.
        /// 
        /// En caso de que el Perfil correspondiente tenga el valor nulo de Género,
        /// y esté en la lista de preguntados, se procesa el valor ingresado en el 
        /// último mensaje para validarlo.
        /// De ser correcto, se modifica el campo Genero de Perfil y se pasa al siguiente eslabón.
        /// De no ser correcto, se pide al usuario que ingrese un valor adecuado.
        /// 
        /// 
        /// Si al ingresar al método, el valor de Genero no es el nulo, se asume que ya fue fijado por el usuario,
        /// por lo que se envía el mensaje hacia el siguiente eslabón. 
        /// </summary>
        /// <param name="m">Mensaje que se transmite por patrón COR</param>
        public override void Handle (Mensaje m)
        {
            if (BibliotecaPerfiles.GetUsuario (m.Id).Genero == TipoGenero.Vacio)
            {
                if (!UsuariosPreguntados.Contains (m.Id))
                {
                    UsuariosPreguntados.Add (m.Id);
                    Preguntar (m.Id);
                }
                else
                {
                    TipoGenero genero;
                    if (masculino.Contains (m.Contenido))
                    {
                        genero = TipoGenero.Masculino;
                    }
                    else if (femenino.Contains (m.Contenido))
                    {
                        genero = TipoGenero.Femenino;
                    }
                    else
                    {
                        genero = TipoGenero.Indefinido;
                    }

                    EditorPerfil.SetGenero (m.Id, genero);
                    //Si está todo OK, paso al siguiente control
                    Siguiente.Handle (m);
                    //EditorPerfil.SetGenero (m.Id, m.Contenido);
                    //Si está todo OK, paso al siguiente control
                    Siguiente.Handle (m);
                }
            }
            else
            {
                Siguiente.Handle (m);
            }
        }
        /// <summary>
        /// Método que se encarga de trasladar a la clase encargada de enviar mensajes al usuario el
        /// pedido por un tipo de género.
        /// </summary>
        public override void Preguntar (long id)
        {
            string pregunta = Respuesta.DefinirFrase (this);
            Respuesta.GenerarRespuesta (pregunta, id);

        }

    }
}