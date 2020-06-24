namespace Library
{
    public class GeneradorPipes : IGeneradorRegalo
    {
        public string SugerenciaRegalo(long idUsuario)
        {
            Perfil target = BibliotecaPerfiles.GetUsuario(idUsuario);
            return "pelota";
        }
    }
}