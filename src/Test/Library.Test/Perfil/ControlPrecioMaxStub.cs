
using Library;
namespace Library.Test.Perfil
{
    internal class ControlPrecioMaxStub: ControlPrecioMax
    {
        public bool passed = false;
        public ControlPrecioMaxStub()
        {
            this.Siguiente = new HandlerStub(SetPassed);
        }
       
        public void SetPassed()
        {
            this.passed = true;
        }

    }
}