using System;
using NUnit.Framework;
using Library;

namespace Library.Test.Perfil
{
    public class TestControlGenero
    {
        [Test]
        public void EntradaDesconocidaSeteaDesconocido()
        {
            BibliotecaPerfiles biblioteca = BibliotecaPerfiles.Instance;
            biblioteca.CrearUsuario(0);
            Mensaje mensaje = new Mensaje("stub", 0,TipoPlataforma.Consola);
            ControlGeneroStub control = new ControlGeneroStub();
            BibliotecaPerfiles.GetUsuario(0).RegistroPreguntas.Genero = true;

            control.Handle(mensaje);

            Assert.AreEqual(TipoGenero.Indefinido, BibliotecaPerfiles.GetUsuario(0).Genero);

        }
        [Test]
        public void SiTodoOKContinuoASiguienteEslabon()
        {
            Library.BibliotecaPerfiles biblioteca = Library.BibliotecaPerfiles.Instance;
            biblioteca.CrearUsuario(0);
            Mensaje mensaje = new Mensaje("Mujer", 0,TipoPlataforma.Consola);
            ControlGeneroStub control = new ControlGeneroStub();
            BibliotecaPerfiles.GetUsuario(0).RegistroPreguntas.Genero = true;

            control.Handle(mensaje);

            Assert.IsTrue(control.passed);

        }
    }
}