using System;
namespace Library
{
    public class EditorPerfil
    {
        public static void SetEdad(long idPerfil, int edad)
        {
            if (edad < 0 || edad > 120)
            {
                throw new ArgumentOutOfRangeException();
            }
            BibliotecaPerfiles.GetUsuario(idPerfil).Edad = edad;
        }
        public static void SetGenero(long idPerfil, TipoGenero genero)
        {
            BibliotecaPerfiles.GetUsuario(idPerfil).Genero = genero;
        }
        public static void SetRelacion (long idPerfil, TipoAfinidad relacion)
        {
            BibliotecaPerfiles.GetUsuario(idPerfil).Relacion = relacion;
        }
        public static void SetInteres (long idPerfil, string interes)
        {
            BibliotecaPerfiles.GetUsuario(idPerfil).Interes = interes;
        }
        public static void SetPrecioMin(long idPerfil, int precioMin)
        {
            if (precioMin < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            BibliotecaPerfiles.GetUsuario(idPerfil).PrecioMin = precioMin;
        }
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