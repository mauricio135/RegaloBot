using System.Threading.Tasks;

namespace Library
{
    public class Despedida : BaseHandler
    {
        public override async void Handle (Mensaje m)
        {
            Perfil perfil = BibliotecaPerfiles.GetUsuario (m.Id);
            await Preguntar (m.Id, m.Plataforma);
            BibliotecaPerfiles.EliminarUsuario (m.Id);

        }
        public async override Task Preguntar (long id, TipoPlataforma plataforma)
        {
            string pregunta = Respuesta.DefinirFrase (this);
            await Respuesta.GenerarRespuesta (pregunta, id, plataforma);
        }
    }
}