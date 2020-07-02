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
            ControlPrecioMaxStub control = new ControlPrecioMaxStub();
            BibliotecaPerfiles.GetUsuario(0).RegistroPreguntas.PrecioMax = true;
            
            control.Handle(mensaje);

            Assert.Throws<FormatException>(() => Int32.Parse(mensaje.Contenido));
        }

        [Test]
        public void PrecioMaxNegativoLanzaExcepcion()
        {
            BibliotecaPerfiles perfil = BibliotecaPerfiles.Instance;
            perfil.CrearUsuario(0);
            Assert.Throws<ArgumentOutOfRangeException>(() => EditorPerfil.SetPrecioMax (0, -21));
        }

        [Test]
        public void PrecioMaxMenorQuePrecioMinLanzaExcepcion()
        {
            BibliotecaPerfiles perfil = BibliotecaPerfiles.Instance;
            perfil.CrearUsuario(0);
            BibliotecaPerfiles.GetUsuario(0).PrecioMin = 500;
            Assert.Throws<ArgumentOutOfRangeException>(() => EditorPerfil.SetPrecioMax (0, 300));

        }

        [Test]
        public void SiPrecioMaxCorrectoSeteaPerfil()
        {
            Library.BibliotecaPerfiles biblioteca = Library.BibliotecaPerfiles.Instance;
            biblioteca.CrearUsuario(0);
            Mensaje mensaje = new Mensaje("25", 0,TipoPlataforma.Consola);
            ControlPrecioMaxStub control = new ControlPrecioMaxStub();
            BibliotecaPerfiles.GetUsuario(0).RegistroPreguntas.PrecioMax = true;

            control.Handle(mensaje);

            Assert.AreEqual(BibliotecaPerfiles.GetUsuario(0).PrecioMax,25);

        }
        
        [Test]
        public void SiTodoOKContinuoASiguienteEslabon()
        {
            Library.BibliotecaPerfiles biblioteca = Library.BibliotecaPerfiles.Instance;
            biblioteca.CrearUsuario(0);
            Mensaje mensaje = new Mensaje("25", 0,TipoPlataforma.Consola);
            ControlPrecioMaxStub control = new ControlPrecioMaxStub();
            BibliotecaPerfiles.GetUsuario(0).RegistroPreguntas.PrecioMax = true;

            control.Handle(mensaje);

            Assert.AreEqual(BibliotecaPerfiles.GetUsuario(0).PrecioMax,25);

            Assert.IsTrue(control.passed);

        }

    }
}