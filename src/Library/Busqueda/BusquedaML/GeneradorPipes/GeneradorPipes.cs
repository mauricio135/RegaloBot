namespace Library
{
    /// <summary>
    /// Clase que implementa IGeneradorRegalo y utiliza el patrón Pipes and Filters para buscar sugerencias de regalo adecuadas a las características de la persona
    /// </summary>
    public class GeneradorPipes : IGeneradorRegalo
    {
        /// <summary>
        /// Dado un perfil, busca en las tendencias de MercadoLibre regalos adecuados.
        /// </summary>
        /// <param name="idUsuario">Número identificador del perfil a buscar.</param>
        /// <returns>Sugerencia de búsqueda</returns>
        public string SugerenciaRegalo(long idUsuario)
        {
            Perfil target = BibliotecaPerfiles.GetUsuario(idUsuario);
            PipeInicial filtro = new PipeInicial();
            return filtro.Filtrar(target);
        }
    }
}