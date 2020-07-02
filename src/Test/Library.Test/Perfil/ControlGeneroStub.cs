
using Library;
namespace Library.Test.Perfil
{
    internal class ControlGeneroStub: ControlGenero
    {
        public bool passed = false;
        public ControlGeneroStub()
        {
            this.Siguiente = new HandlerStub(SetPassed);
        }
       
        public void SetPassed()
        {
            this.passed = true;
        }

    }
}