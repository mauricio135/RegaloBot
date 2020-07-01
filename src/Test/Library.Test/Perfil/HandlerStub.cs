using Library;
using System;
namespace Library.Test.Perfil
{
    internal class HandlerStub : IHandler
    {
        private Action flag;
        public IHandler Siguiente { set => throw new System.NotImplementedException(); }

        public void Handle(Mensaje m)
        {
            this.flag();
        }
        public HandlerStub (Action action)
        {
            this.flag = action;
        }
    }
}