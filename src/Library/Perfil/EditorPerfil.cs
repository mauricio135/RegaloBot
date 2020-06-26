namespace Library
{
    public class EditorPerfil
    {
        public static void SetEdad(long idPerfil, int edad)
        {
            BibliotecaPerfiles.GetUsuario(idPerfil).Edad = edad;
        }
        public static void SetGenero(long idPerfil, TipoGenero genero)
        {
            BibliotecaPerfiles.GetUsuario(idPerfil).Genero = genero;
        }
        public static void SetRelacion (long idPerfil, string relacion)
        {
            BibliotecaPerfiles.GetUsuario(idPerfil).Relacion = relacion;
        }
        public static void SetInteres (long idPerfil, string interes)
        {
            BibliotecaPerfiles.GetUsuario(idPerfil).Interes = interes;
        }
        public static void SetPrecioMin(long idPerfil, int precioMin)
        {
            BibliotecaPerfiles.GetUsuario(idPerfil).PrecioMin = precioMin;
        }
        public static void SetPrecioMax(long idPerfil, int precioMax)
        {
            BibliotecaPerfiles.GetUsuario(idPerfil).PrecioMax = precioMax;
        }
    }
}