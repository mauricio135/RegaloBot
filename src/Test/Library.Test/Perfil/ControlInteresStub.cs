
using Library;
namespace Library.Test.Perfil
{
    internal class ControlInteresStub: ControlInteres
    {
        public bool passed = false;
        public ControlInteresStub()
        {
            this.Siguiente = new HandlerStub(SetPassed);
        }
       
        public void SetPassed()
        {
            this.passed = true;
        }

    }
}