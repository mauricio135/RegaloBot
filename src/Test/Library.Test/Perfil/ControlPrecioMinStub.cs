
using Library;
namespace Library.Test.Perfil
{
    internal class ControlPrecioMinStub: ControlPrecioMax
    {
        public bool passed = false;
        public ControlPrecioMinStub()
        {
            this.Siguiente = new HandlerStub(SetPassed);
        }
       
        public void SetPassed()
        {
            this.passed = true;
        }

    }
}