
using Library;
namespace Library.Test.Perfil
{
    internal class ControlEdadStub: ControlEdad
    {
        public bool passed = false;
        public ControlEdadStub()
        {
            this.Siguiente = new HandlerStub(SetPassed);
        }
        public void SetPreguntados(long id)
        {
            this.UsuariosPreguntados.Add(id);
        }
        public void SetPassed()
        {
            this.passed = true;
        }

    }
}