using System;
using NUnit.Framework;
using Library;

namespace Library.Test.Perfil
{
    public class TestControlprecioMax
    {
        [Test]
        public void NoIngresaNumeroLanzaExcepcion()
        {
            Library.BibliotecaPerfiles biblioteca = Library.BibliotecaPerfiles.Instance;
            biblioteca.CrearUsuario(0);
            Mensaje mensaje = new Mensaje("stub", 0,TipoPlataforma.Consola);
            ControlEdadStub control = new ControlEdadStub();
            BibliotecaPerfiles.GetUsuario(0).RegistroPreguntas.Edad = true;

            control.Handle(mensaje);

            Assert.Throws<FormatException>(() => Int32.Parse(mensaje.Contenido));
        }

        [Test]
        public void EdadNegativaLanzaExcepcion()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => EditorPerfil.SetEdad (0, -21));
        }

        [Test]
        public void EdadMuyGrandeLanzaExcepcion()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => EditorPerfil.SetEdad (0, 300));
        }

        [Test]
        public void SiTodoOKSeteaEdad()
        {
            Library.BibliotecaPerfiles biblioteca = Library.BibliotecaPerfiles.Instance;
            biblioteca.CrearUsuario(0);
            Mensaje mensaje = new Mensaje("25", 0,TipoPlataforma.Consola);
            ControlEdadStub control = new ControlEdadStub();
            BibliotecaPerfiles.GetUsuario(0).RegistroPreguntas.Edad = true;

            control.Handle(mensaje);

            Assert.AreEqual(BibliotecaPerfiles.GetUsuario(0).Edad,25);

        }
        
        [Test]
        public void SiTodoOKContinuoASiguienteEslabon()
        {
            Library.BibliotecaPerfiles biblioteca = Library.BibliotecaPerfiles.Instance;
            biblioteca.CrearUsuario(0);
            Mensaje mensaje = new Mensaje("25", 0,TipoPlataforma.Consola);
            ControlEdadStub control = new ControlEdadStub();
            BibliotecaPerfiles.GetUsuario(0).RegistroPreguntas.Edad = true;

            control.Handle(mensaje);

            Assert.IsTrue(control.passed);

        }



    }
}