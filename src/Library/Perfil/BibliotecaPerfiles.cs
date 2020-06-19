using System.Collections.Generic;
namespace Library
{
    /// <summary>
    /// Clase que contiene a todos los perfiles creados. Permite crear usuarios, acceder a ellos o verificar la existencia de un usuario dado un ID.
    /// </summary>
    public class BibliotecaPerfiles
    {
        /// <summary>
        /// Constructor privado para asegurar una única instancia de esta clase que contenga a todos los perfiles.
        /// Se aplica el patrón Singleton para evitar que se genere una segunda instancia que contenga elementos aislados.
        /// </summary>
        private BibliotecaPerfiles()
        {

        }
        public static List<Perfil> lista = new List<Perfil>();
        private static BibliotecaPerfiles instance;

        /// <summary>
        /// Propiedad que permite el acceso a la única instancia de la clase
        /// </summary>
        /// <value></value>
        public static BibliotecaPerfiles Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BibliotecaPerfiles();
                }

                return instance;
            }
        }
        /// <summary>
        /// Método que verifica la existencia de un usuario, dado un número ID.
        /// </summary>
        /// <param name="idIngresado">Parámetro del tipo long que identifica a cada Perfil</param>
        /// <returns>Retorna true si en la Biblioteca de perfiles hay un Perfil identificado con ese ID, y false en caso contrario.</returns>
        public bool ExisteUsuario(long idIngresado)
        {
            foreach (Perfil usuario in lista)
            {
                if (usuario.Id == idIngresado)
                {
                    return true;
                }      
            }
            return false;
        }
        /// <summary>
        /// Como BibliotecaPerfiles guarda instancias de Perfil, aplicando Creator, la primera tiene la responsabilidad de crear
        /// instancias de la segunda. De esta manera, además, se asegura que toda instancia de Perfil creada se añada a
        /// la lista de BibliotecaPerfiles.
        /// </summary>
        /// <param name="idNuevo">Número de ID de la conversación desde la que se interactúa. Es un atributo único para cada Perfil</param>
        public void CrearUsuario (long idNuevo)
        {
            Perfil nuevoUsuario = new Perfil(idNuevo);
            lista.Add(nuevoUsuario);
        }
        /// <summary>
        /// Dado un número de ID, devuelve la instancia de Perfil correspondiente.
        /// </summary>
        /// <param name="idUsuario">Número ID identificador del perfil</param>
        /// <returns>Devuelve la instancia de perfil correspondiente al ID provisto.
        /// En caso de que no exista, devuelve null.</returns>
        public static Perfil GetUsuario (long idUsuario)
        {
            foreach (Perfil usuario in lista)
            {
                if (usuario.Id == idUsuario)
                {
                    return usuario;
                }      
            }
            return null;
        }

    }
}