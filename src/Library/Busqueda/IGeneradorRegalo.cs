namespace Library
{
    /// <summary>
    /// Interfaz que, dado un número que identifica a un Perfil, debe devolver un string con una recomendación para buscar en la tienda
    /// </summary>
    public interface IGeneradorRegalo
    {
        string SugerenciaRegalo(long idUsuario);
    }
}