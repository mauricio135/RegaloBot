namespace Library
{
    public class GeneradorPipes : IGeneradorRegalo
    {
        public string SugerenciaRegalo(long idUsuario)
        {
            Perfil target = BibliotecaPerfiles.GetUsuario(idUsuario);
            PipeInicial filtro = new PipeInicial();
            return filtro.Filtrar(target);
        }
    }
}