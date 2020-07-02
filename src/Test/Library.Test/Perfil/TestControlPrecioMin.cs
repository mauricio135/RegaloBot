using System;
using NUnit.Framework;
using Library;

namespace Library.Test.Perfil
{
    public class TestControlprecioMin
    {
        [Test]
        public void NoIngresaNumeroLanzaExcepcion()
        {
            Library.BibliotecaPerfiles biblioteca = Library.BibliotecaPerfiles.Instance;
            biblioteca.CrearUsuario(0);
            Mensaje mensaje = new Mensaje("stub", 0,TipoPlataforma.Consola);
            ControlPrecioMinStub control = new ControlPrecioMinStub();
            BibliotecaPerfiles.GetUsuario(0).RegistroPreguntas.PrecioMin = true;
            
            control.Handle(mensaje);

            Assert.Throws<FormatException>(() => Int32.Parse(mensaje.Contenido));
        }

        [Test]
        public void PrecioMinNegativoLanzaExcepcion()
        {
            BibliotecaPerfiles perfil = BibliotecaPerfiles.Instance;
            perfil.CrearUsuario(0);
            Assert.Throws<ArgumentOutOfRangeException>(() => EditorPerfil.SetPrecioMin (0, -21));
        }

        [Test]
        public void PrecioMinMayorQuePrecioMaxLanzaExcepcion()
        {
            BibliotecaPerfiles perfil = BibliotecaPerfiles.Instance;
            perfil.CrearUsuario(0);
            BibliotecaPerfiles.GetUsuario(0).PrecioMin = 500;
            Assert.Throws<ArgumentOutOfRangeException>(() => EditorPerfil.SetPrecioMax (0, 300));

        }

        [Test]
        public void SiPrecioMinCorrectoSeteaPerfil()
        {
            Library.BibliotecaPerfiles biblioteca = Library.BibliotecaPerfiles.Instance;
            biblioteca.CrearUsuario(0);
            Mensaje mensaje = new Mensaje("45", 0,TipoPlataforma.Consola);
            ControlPrecioMinStub control = new ControlPrecioMinStub();
            BibliotecaPerfiles.GetUsuario(0).RegistroPreguntas.PrecioMin = true;

            control.Handle(mensaje);

            Assert.AreEqual(BibliotecaPerfiles.GetUsuario(0).PrecioMin,45);

        }

    }
}