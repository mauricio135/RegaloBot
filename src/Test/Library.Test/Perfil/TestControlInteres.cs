using System;
using NUnit.Framework;
using Library;

namespace Library.Test.Perfil
{
    public class TestControlInteres
    {
        [Test]
        public void SiTodoOKContinuoASiguienteEslabon()
        {
            Library.BibliotecaPerfiles biblioteca = Library.BibliotecaPerfiles.Instance;
            biblioteca.CrearUsuario(0);
            Mensaje mensaje = new Mensaje("Rock", 0,TipoPlataforma.Consola);
            ControlInteresStub control = new ControlInteresStub();
            BibliotecaPerfiles.GetUsuario(0).RegistroPreguntas.Interes = true;

            control.Handle(mensaje);

            Assert.IsTrue(control.passed);

        }
    }
}