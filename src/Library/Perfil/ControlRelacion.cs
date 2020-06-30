using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Tercer eslabón del patrón Chain Of Responsibility. Se encarga de recibir la relación con el homenajeado
    /// del Perfil que se crea, efectuando los controles necesarios para obtener un  parámetro válido.
    /// </summary>
    public class ControlRelacion : BaseHandler
    {
        private static List<string> muyCercano = new List<string> ()
        {
            "padre",
            "madre",
            "hermano",
            "hermana",
            "hijo",
            "hija",
            "novio",
            "novia",
            "esposo",
            "esposa",
            "amante",
            "pareja",
            "mejor amigo",
            "mejor amiga",
            "mi mujer",
            "mi marido",
            "para mi",
            "yo"
        };

        private static List<string> cercano = new List<string> ()
        {
            "tio",
            "tia",
            "primo",
            "prima",
            "madrina",
            "padrino",
            "abuela",
            "abuelo",
            "amigo",
            "amiga",
            "sobrino",
            "sobrina",
            "ahijado",
            "ahijada",
            "suegro",
            "suegra"

        };
        private static List<string> conocido = new List<string> ()
        {
            "compañero",
            "compañera",
            "compañero de trabajo",
            "compañera de trabajo",
            "conocido",
            "conocida",
            "jefe",
            "jefa",
            "vecino",
            "vecina",
            "familiar"
        };

        private static List<string> desconocido = new List<string> ()
        {
            "no se",
            "no",
            "alguien",
            "nadie",
            "no importa"
        };

        /// <summary>
        /// Como ControlRelacion contiene un objeto del tipo ControlInteres (siguiente eslabón de COR), aplicamos
        /// patrón Creator para asignarle a ControlRelacion la responsabilidad de crear objetos ControlInteres.
        /// </summary>
        public ControlRelacion ()
        {
            this.Siguiente = new ControlInteres ();
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
        public override async void Handle (Mensaje m)
        {
            if (BibliotecaPerfiles.GetUsuario (m.Id).Relacion == TipoAfinidad.Vacio)
            {
                if (!UsuariosPreguntados.Contains (m.Id))
                {
                    UsuariosPreguntados.Add (m.Id);
                    await Preguntar (m.Id);
                }
                else
                {
                    try
                    {
                        TipoAfinidad afinidad = BuscoAfinidad (m.Contenido);
                        EditorPerfil.SetRelacion (m.Id, afinidad);
                        Siguiente.Handle (m);
                    }
                    catch (ArgumentException)
                    {
                       await Respuesta.PedirAclaracion (m.Id);
                       await  Preguntar (m.Id);

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
        /// pedido por un tipo de relación.
        /// </summary>
        public override async Task Preguntar (long id)
        {
            string pregunta = Respuesta.DefinirFrase (this);
            await Respuesta.GenerarRespuesta (pregunta, id);

        }
        private TipoAfinidad BuscoAfinidad (string mensaje)
        {

            TipoAfinidad relacion;
            if (muyCercano.Contains (mensaje.ToLower ()))
            {
                relacion = TipoAfinidad.MuyCercano;
            }
            else if (cercano.Contains (mensaje.ToLower ()))
            {
                relacion = TipoAfinidad.Cercano;
            }
            else if (conocido.Contains (mensaje.ToLower ()))
            {
                relacion = TipoAfinidad.Conocido;
            }
            else if (desconocido.Contains (mensaje.ToLower ()))
            {
                relacion = TipoAfinidad.Desconocido;
            }
            else
            {
                throw new ArgumentException ();
            }

            return relacion;

        }
    }
}