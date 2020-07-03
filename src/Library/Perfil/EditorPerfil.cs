using System;
namespace Library
{
    /// <summary>
    /// Clase que contiene métodos para configurar los distintos atributos de Perfil, aplicando controles
    /// </summary>
    public class EditorPerfil
    {
        /// <summary>
        /// Fija el valor de la edad del perfil.static No acepta valores negativos ni mayores a 120
        /// </summary>
        /// <param name="idPerfil">Número identificador del Perfil</param>
        /// <param name="edad">Valor nuevo de la edad</param>
        public static void SetEdad(long idPerfil, int edad)
        {
            if (edad < 0 || edad > 120)
            {
                throw new ArgumentOutOfRangeException();
            }
            BibliotecaPerfiles.GetUsuario(idPerfil).Edad = edad;
        }
        /// <summary>
        /// Fija el tipo de género del Perfil
        /// </summary>
        /// <param name="idPerfil">Número identificador del Perfil</param>
        /// <param name="genero">Valor nuevo del género</param>
        public static void SetGenero(long idPerfil, TipoGenero genero)
        {
            BibliotecaPerfiles.GetUsuario(idPerfil).Genero = genero;
        }
        /// <summary>
        /// Fija el tipo de relación del Perfil
        /// </summary>
        /// <param name="idPerfil">Número identificador del Perfil</param>
        /// <param name="relacion">Valor nuevo de la relación</param>
        public static void SetRelacion (long idPerfil, TipoAfinidad relacion)
        {
            BibliotecaPerfiles.GetUsuario(idPerfil).Relacion = relacion;
        }
        /// <summary>
        /// Fija el interés del Perfil
        /// </summary>
        /// <param name="idPerfil">Número identificador del Perfil</param>
        /// <param name="interes">Interés a agregar</param>
        public static void SetInteres (long idPerfil, string interes)
        {
            BibliotecaPerfiles.GetUsuario(idPerfil).Interes = interes;
        }
        /// <summary>
        /// Fija el precio mínimo del Perfil. No acepta valores negativos
        /// </summary>
        /// <param name="idPerfil">Número identificador del Perfil</param>
        /// <param name="precioMin">Valor nuevo del precio mínimo</param>
        public static void SetPrecioMin(long idPerfil, int precioMin)
        {
            if (precioMin < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            BibliotecaPerfiles.GetUsuario(idPerfil).PrecioMin = precioMin;
        }
        /// <summary>
        /// Fija el precio máximo del Perfil. No acepta valores negativos ni menores al precio mínimo
        /// </summary>
        /// <param name="idPerfil">Número identificador del Perfil</param>
        /// <param name="precioMax">Valor nuevo del precio máximo</param>
        public static void SetPrecioMax(long idPerfil, int precioMax)
        {
            if ((precioMax < BibliotecaPerfiles.GetUsuario(idPerfil).PrecioMin)||
            precioMax < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            BibliotecaPerfiles.GetUsuario(idPerfil).PrecioMax = precioMax;
        }
    }
}